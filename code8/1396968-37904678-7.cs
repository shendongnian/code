    int rowLength = matrix.GetLength(0);
    int colLength = matrix.Rank;
    for (int i = 0; i < rowLength; i++) {
        for (int j = 0; j < colLength; j++) {
            Console.Write(string.Format("{0} ", matrix[i, j]));
        }
        Console.WriteLine();
        Console.WriteLine();
    }
    Console.ReadLine();
