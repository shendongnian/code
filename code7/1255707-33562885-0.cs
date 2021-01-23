     public static int GetLCS(string str1, string str2)
        {
            int[,] table;
            return GetLCSInternal(str1, str2, out table);
        }
        private static int GetLCSInternal(string str1, string str2, out int[,] matrix)
        {
            matrix = null;
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
            {
                return 0;
            }
            int[,] table = new int[str1.Length + 1, str2.Length + 1];
            for (int i = 0; i < table.GetLength(0); i++)
            {
                table[i, 0] = 0;
            }
            for(int j= 0;j<table.GetLength(1); j++)
            {
                table[0,j] = 0;
            }
            for (int i = 1; i < table.GetLength(0); i++)
            {
                for (int j = 1; j < table.GetLength(1); j++)
                {
                    if (str1[i-1] == str2[j-1])
                        table[i, j] = table[i - 1, j - 1] + 1;
                    else
                    {
                        if (table[i, j - 1] > table[i - 1, j])
                            table[i, j] = table[i, j - 1];
                        else
                            table[i, j] = table[i - 1, j];
                    }
                }
            }
            matrix = table;
            return table[str1.Length, str2.Length];
        }
