    public static int[,] MatrixConstructor()
    {
        int N = Convert.ToInt32(Console.ReadLine());
        int[,] matrix = new int[N, N];
        for (int i = 0; i < N; i++)
        {
            String[] line = Console.ReadLine().Split(' ');
            for (int j = 0; j < N; j++)
            {
                matrix[i,j] = Convert.ToInt32(line[j]);
            }
        }
        return matrix;
    }
