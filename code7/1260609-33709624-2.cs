    public static void PrintMatrix(int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            var csv = string.Join(",", matrix[i]);
            Console.WriteLine(string.Format("[{0}]", csv));
        }
    }
