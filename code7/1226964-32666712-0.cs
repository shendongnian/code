        for (int i = 0; i < list.GetLength(0); i++)
        {
            for (int j = 0; j < list.GetLength(1); j++)
            {
                if (list[i, j] == n)
                {
                    c++;
                }
            }
        }
