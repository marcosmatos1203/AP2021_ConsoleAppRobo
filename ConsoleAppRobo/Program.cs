using System;

namespace ConsoleAppRobo
{
    class Program
    {
        static void Main(string[] args)
        {
            int abscissaArea, ordenadaArea, abscissaRobo01, ordenadaRobo01, abscissaRobo02, ordenadaRobo02;
            string direcaoInicialRobo01, comandosRobo01, direcaoInicialRobo02, comandosRobo02;

            AreaDeExploracao(out abscissaArea, out ordenadaArea);

            InicialRobo(out abscissaRobo01, out ordenadaRobo01, "ROBO_01");
            Console.Clear();
            InfomaDirecao("ROBO_01");
            direcaoInicialRobo01 = Console.ReadLine().ToUpper();

            Console.Clear();
            InformaComandos();
            comandosRobo01 = Console.ReadLine().ToUpper();
            Console.Clear();

            InicialRobo(out abscissaRobo02, out ordenadaRobo02, "ROBO_02");
            Console.Clear();
            InfomaDirecao("ROBO_02");
            direcaoInicialRobo02 = Console.ReadLine().ToUpper();
            Console.Clear();
            InformaComandos();
            comandosRobo02 = Console.ReadLine().ToUpper();
            Console.Clear();

            Console.WriteLine("------------------------------");
            Console.WriteLine($"Àrea de exploração = ({abscissaArea}, {ordenadaArea})");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("------------------------------");

            ApresentaPosicaoInicialRobo(abscissaRobo01, ordenadaRobo01, direcaoInicialRobo01, "ROBO_01");

            RetonaPosicaoFinal(ref abscissaRobo01, ref ordenadaRobo01, ref direcaoInicialRobo01, comandosRobo01, comandosRobo01.Length);
            ApresentaPosicaoFinalRobo(abscissaArea, ordenadaArea, abscissaRobo01, ordenadaRobo01, direcaoInicialRobo01, "ROBO_01");

            ApresentaPosicaoInicialRobo(abscissaRobo02, ordenadaRobo02, direcaoInicialRobo02, "ROBO_02");

            RetonaPosicaoFinal(ref abscissaRobo02, ref ordenadaRobo02, ref direcaoInicialRobo02, comandosRobo02, comandosRobo02.Length);
            ApresentaPosicaoFinalRobo(abscissaArea, ordenadaArea, abscissaRobo02, ordenadaRobo02, direcaoInicialRobo02, "ROBO_02");

        }

        private static void ApresentaPosicaoFinalRobo(int abscissaArea, int ordenadaArea, int abscissaRobo, int ordenadaRobo, string direcaoInicialRobo, string robo)
        {
            if (abscissaRobo >= abscissaArea || ordenadaRobo >= ordenadaArea)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Comandos levaram o {robo} para fora da àrea de exploração");
                Console.WriteLine($"Àrea desconhecida = ({abscissaRobo}, {ordenadaRobo})");
                Console.WriteLine($"com face virada para o {RetornaDirecao(direcaoInicialRobo)}");
                Console.ResetColor();
                Console.WriteLine("------------------------------");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Posição final do {robo} = ({abscissaRobo}, {ordenadaRobo})");
                Console.WriteLine($"com face virada para o {RetornaDirecao(direcaoInicialRobo)}");
                Console.WriteLine("------------------------------");
                Console.WriteLine();
            }
        }

        private static void ApresentaPosicaoInicialRobo(int abscissaRobo, int ordenadaRobo, string direcaoInicialRobo, string robo)
        {
            Console.WriteLine($"Posição inicial do {robo} = ({abscissaRobo}, {ordenadaRobo})");
            Console.WriteLine($"com face virada para o {RetornaDirecao(direcaoInicialRobo)}");
            Console.WriteLine("");
        }

        private static void RetonaPosicaoFinal(ref int abscissaRobo1, ref int ordenadaRobo1, ref string direcaoInicialRobo_01, string comandosRobo_01, int qComando)
        {
            for (int i = 0; i < comandosRobo_01.Length; i++)
            {
                if (direcaoInicialRobo_01 == "N" && comandosRobo_01.Substring(i, 1) == "M")
                    ordenadaRobo1++;
                else if (direcaoInicialRobo_01 == "N" && comandosRobo_01.Substring(i, 1) == "E")
                    direcaoInicialRobo_01 = "O";
                else if (direcaoInicialRobo_01 == "N" && comandosRobo_01.Substring(i, 1) == "D")
                    direcaoInicialRobo_01 = "L";

                else if (direcaoInicialRobo_01 == "S" && comandosRobo_01.Substring(i, 1) == "M")
                    ordenadaRobo1--;
                else if (direcaoInicialRobo_01 == "S" && comandosRobo_01.Substring(i, 1) == "E")
                    direcaoInicialRobo_01 = "L";
                else if (direcaoInicialRobo_01 == "S" && comandosRobo_01.Substring(i, 1) == "D")
                    direcaoInicialRobo_01 = "O";

                else if (direcaoInicialRobo_01 == "L" && comandosRobo_01.Substring(i, 1) == "M")
                    abscissaRobo1++;
                else if (direcaoInicialRobo_01 == "L" && comandosRobo_01.Substring(i, 1) == "E")
                    direcaoInicialRobo_01 = "N";
                else if (direcaoInicialRobo_01 == "L" && comandosRobo_01.Substring(i, 1) == "D")
                    direcaoInicialRobo_01 = "S";

                else if (direcaoInicialRobo_01 == "O" && comandosRobo_01.Substring(i, 1) == "M")
                    abscissaRobo1--;
                else if (direcaoInicialRobo_01 == "O" && comandosRobo_01.Substring(i, 1) == "E")
                    direcaoInicialRobo_01 = "S";
                else if (direcaoInicialRobo_01 == "O" && comandosRobo_01.Substring(i, 1) == "D")
                    direcaoInicialRobo_01 = "N";

            }
        }


        private static string RetornaDirecao(string direcao)
        {
            string retornoDirecao;
            if (direcao == "N")
                retornoDirecao = "NORTE";
            else if (direcao == "S")
                retornoDirecao = "SUL";
            else if (direcao == "L")
                retornoDirecao = "LESTE";
            else
                retornoDirecao = "OESTE";
            return retornoDirecao;
        }

        private static void AreaDeExploracao(out int abscissa, out int ordenada)
        {
            Console.WriteLine("------Digite o tamanho da àrea-------------");
            Console.WriteLine("Comece digitando o número de linhas do grid");
            int.TryParse(Console.ReadLine(), out abscissa);
            Console.WriteLine("Agora digite o número de colunas do grid");
            int.TryParse(Console.ReadLine(), out ordenada);
        }

        private static void InicialRobo(out int cordenadaXrobo, out int cordenadaYrobo, string robo)
        {
            Console.WriteLine($"-----Entre com os dados iniciais do {robo}--------");
            Console.WriteLine($"Digite em qual coluna do grid o {robo} vai iniciar");
            int.TryParse(Console.ReadLine(), out cordenadaXrobo);
            Console.WriteLine($"Digite em qual linha do grid o {robo} vai iniciar");
            int.TryParse(Console.ReadLine(), out cordenadaYrobo);
        }

        private static void InformaComandos()
        {
            Console.WriteLine("Digite os comandos de exploração da área");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite E para mover 90° para a esquerda");
            Console.WriteLine("Digite D para mover 90° para a direita");
            Console.WriteLine("Digite M para mover para frente");
        }

        private static void InfomaDirecao(string robo)
        {
            Console.WriteLine($"Digite em qual direção o {robo} esta olhando");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Digite N para Norte");
            Console.WriteLine("Digite S para Sul");
            Console.WriteLine("Digite L para Leste");
            Console.WriteLine("Digite O para Oeste");
        }
    }
}
