using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {

        public static void printMatrix(string[,] matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static string[,] initMatrix(string[,] matrix, string symbol)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = symbol;
                }
            }
            return matrix;
        }

        public static void setValue(string[,] matrix, int coordX, int coordY, string symbol)
        {
            if(matrix[2 - coordY, coordX].Contains("-"))
            {
                matrix[2 - coordY, coordX] = symbol;
            }
            else
            {
                Console.WriteLine("Ya esta ocupado compa, pierde turno por wey");
            }
        }

        public static bool checkWinner(string[,] matrix)
        {
            printMatrix(matrix);
            bool winner = true;

            for (
                int i = 0; i < 3; i++)
            {
                if (matrix[i, 0].Contains("-") || matrix[0, i].Contains("-"))
                {
                    break;
                }
                else if (matrix[i, 0].Contains(matrix[i, 1]) && matrix[i, 0].Contains(matrix[i, 2]))
                {
                    Console.WriteLine("Gano el compa con las " + matrix[i, 0]);
                    return winner;
                } else if (matrix[0, i].Contains(matrix[1, i]) && matrix[0, i].Contains(matrix[2, i]))
                {
                    Console.WriteLine("Gano el compa con las " + matrix[0, i]);
                    return winner;
                }
            }

            if (((matrix[0, 0].Contains(matrix[1, 1]) && matrix[0, 0].Contains(matrix[2, 2])) ||
               (matrix[0, 2].Contains(matrix[1, 1]) && matrix[0, 2].Contains(matrix[2, 0]))) &&
               !matrix[1, 1].Contains("-"))
            {
                Console.WriteLine("Gano el compa con las " + matrix[1, 1]);
                return winner;
            }

            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(matrix[i,j].Contains("-"))
                    {
                        return !winner;
                    }
                }
            }
            //Worst case cuando se lleno el tablero
            Console.WriteLine("Empate compas, suerte para la proxima");
            return winner;
        }

        static void Main(string[] args)
        {
            /* - - -
             * - - -
             * - - -
             */

            bool playing = true;
            // Turno == true quiere decir que esta jugando X
            // Turno == false quiere decir que esta jugando O
            bool turno = true;
            string[,] juego = new string[3,3];

            juego = initMatrix(juego, "-");

            while(playing)
            {
                int coordX;
                int coordY;
                if(turno)
                {
                    
                    Console.WriteLine("En donde quieres poner la X");
                    Console.WriteLine("Valor de coordenada X: ");
                    while (!Int32.TryParse(Console.ReadLine(), out coordX))
                    {
                        Console.WriteLine("No me de basura compa, puro numerito");
                        Console.WriteLine("Valor de coordenada X: ");
                    }
                    Console.WriteLine("Valor de coordenada Y: ");
                    while (!Int32.TryParse(Console.ReadLine(), out coordY))
                    {
                        Console.WriteLine("No me de basura compa, puro numerito");
                        Console.WriteLine("Valor de coordenada Y: ");
                    }

                    if (coordX > 2 || coordY > 2)
                    {
                        Console.WriteLine("C mamo");
                    }
                    else
                    {
                        setValue(juego, coordX, coordY, "X");
                        playing = !checkWinner(juego);
                        turno = !turno;
                    }
                }
                else
                {
                    Console.WriteLine("En donde quieres poner la O");
                    Console.WriteLine("Valor de coordenada X: ");
                    while(!Int32.TryParse(Console.ReadLine(), out coordX))
                    {
                        Console.WriteLine("No me de basura compa, puro numerito");
                        Console.WriteLine("Valor de coordenada X: ");
                    }
                  
                    Console.WriteLine("Valor de coordenada Y: ");
                    while(!Int32.TryParse(Console.ReadLine(), out coordY))
                    {
                        Console.WriteLine("No me de basura compa, puro numerito");
                        Console.WriteLine("Valor de coordenada Y: ");
                    }
                    if (coordX > 2 || coordY > 2)
                    {
                        Console.WriteLine("c marnat");
                    }
                    else
                    {
                        setValue(juego, coordX, coordY, "O");
                        playing = !checkWinner(juego);
                        turno = !turno;
                    }
                }
            }

            //printMatrix(juego);



            Console.ReadKey();
        }
    }
}
