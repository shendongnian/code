    for (int i = 0; i < array.GetLength(1); i++)
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            if (j == 0)
            {
                Console.WriteLine("Nothing");
            }
            else if (array[j, i] == array[j - 1, i])
            {
                Console.WriteLine("Duplicate No." + array[i, j].ToString());
            }
        }
    }
