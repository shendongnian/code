    public void FillArray(int[,] array)
    {
        Random rnd = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < tempArray.GetLength(1); j++)
            {
                array[i, j] = rnd.Next(1, 15);
            }
        }
    }
