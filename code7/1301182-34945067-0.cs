    string[,] strings = new string[,] { { "1", "2", "3" }, { "4", "5", "6" } };
    int[,] ints = new int[strings.GetLength(0), strings.GetLength(1)];
    
    for (int i = 0; i < strings.GetLength(0); i++)
    {
        for (int j = 0; j < strings.GetLength(1); j++)
        {
            int.TryParse(strings[i, j], out ints[i, j]);
        }
    }
