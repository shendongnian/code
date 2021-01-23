    static void Main(string[] args)
    {
        Matrix<double[,]> src = BuildMetaMatrix();
        double[,] dest = Flatten(src);
        Print(dest);
        Console.ReadLine();
    }
    static void Print(double[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(ROW_DIM); row++)
        {
            for (int col = 0; col < matrix.GetLength(COL_DIM); col++)
            {
                Console.Write(matrix[row, col] + "\t");
            }
            Console.Write("\n");
        }
    }
