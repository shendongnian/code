    class Program
    {
        static void Main(string[] args)
        {
            int size;
            Console.WriteLine("Please enter the size of the matrix:");
            if (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("The value provided for the size was not a proper integer value.");
                Console.WriteLine("Press ESC to quit...");
                while (Console.ReadKey().Key != ConsoleKey.Escape) { }
                return;
            }
    
            int[,] matrix = new int[size, size];
    
            for (int i = 0; i < size; ++i)
            {
                bool complete = false;
                while (!complete)
                {
                    Console.WriteLine(string.Format("[{0}] - Please input {1} integers(separated by spaces):", i, size));
                    string[] input = Console.ReadLine().Split(' ');
                    if (input.Count() != size)
                    {
                        Console.WriteLine("The input was invalid, try again...");
                        continue;
                    }
                    for (int j = 0; j < size; ++j)
                    {
                        if (!int.TryParse(input[j], out matrix[i, j]))
                        {
                            complete = false;
                            Console.WriteLine("The input was invalid, try again...");
                            break;
                        }
                        complete = true;
                    }
                    
                }
            }
            Console.WriteLine("Output: \n");
            WriteMatrix(matrix, size);
            Console.ReadKey();
        }
    
        private static void WriteMatrix(int[,] matrix, int size)
        {
            string output = string.Empty;
            for(int i = 0; i < size; ++i)
            {
                string line = string.Empty;
                for (int j = 0; j < size; ++j)
                    line += string.Format("{0} ", matrix[i, j]);
                output += string.Format("{0}\n", line.Trim());
            }
            Console.WriteLine(output);
        }
    
    }
