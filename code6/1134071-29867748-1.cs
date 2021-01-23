    public static int[][] Matrix(int rows, int columns)
    {
        int[][] lottery = new int[rows][];
        for (int i = 0; i < lottery.Length; i++)
        {
            ShuffledRow sr = new ShuffledRow(1, 46);
                
            lottery[i] = sr.Row;
            Array.Resize(ref lottery[i], columns);
            Console.WriteLine(string.Join(",", lottery[i].Select(x => string.Format("{0,3}", x))));
        }
        return lottery;
    }
    public static int[][] Matrix(int rows, int columns)
    {
        int[][] lottery = new int[rows][];
        for (int i = 0; i < lottery.Length; i++)
        {
            ShuffledRow sr = new ShuffledRow(1, 46);
            lottery[i] = new int[columns];
            for (int j = 0; j < columns; j++)
            {
                lottery[i][j] = sr.Row[j];
                Console.Write("{0,3},", lottery[i][j]);
            }
            Console.WriteLine();
        }
        return lottery;
    }
