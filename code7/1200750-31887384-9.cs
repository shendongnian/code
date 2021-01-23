        static void Main(string[] args)
        {
            GetConstraints();
            bool solvable = SolveSudokuGrid();
            if(!solvable) Console.WriteLine("Cannot solve!");
            else  PrintGrid();
            Console.Read();
        }
