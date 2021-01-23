    private static readonly string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H" };
        private const int size = 8;
        private static bool[,] chessboard;
        private static void Main()
        {
            const string top = " -----------------";
            //init chessboard
            chessboard = new bool[size, size];
            //place a figure on field 4/6 for demonstration
            chessboard[4, 6] = true;
            for (int y = 0; y < size; y++)
            {
                Console.WriteLine(" {0}", top);
                Console.Write("{0} ", size - y);
                for (int x = 0; x < size; x++)
                {
                    Console.Write("|{0}", chessboard[x, y] ? 'X' : ' ');
                }
                Console.WriteLine("|");
            }
            Console.Write("   ");
            for (int i = 0; i < size; i++)
            {
                Console.Write("{0} ", letters[i]);
            }
            Console.ReadKey();
        }
