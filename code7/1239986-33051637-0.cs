    Console.WriteLine("Enter the matrix size");
    int n = Convert.ToInt32(Console.ReadLine());
    //add size and other validation if required
    int[,] matrix = new int[n, n];
    Console.WriteLine("Enter your values separated by space.");
    for (int i = 0; i < n; i++)
    {
        var values = (Console.ReadLine().Split(' '));
        for (int j = 0; j < n; j++)
        {
            matrix[i, j] = int.Parse(values[j]);
        }
    }
    //to write 
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
