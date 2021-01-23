            int[,,] x = new int[10, 8, 8];
            int[] temp = new int[x.Length];
            #region one dimensional array unique numbers.
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = r.Next(10, 650);
                for (int j = 0; j < i; j++)
                {
                    if (temp[i] == temp[j])
                    {
                        i--;
                        break;
                    }
                }
            }
            #endregion
            for (int i = 0, index = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    for (int k = 0; k < x.GetLength(2); k++)
                    {
                        x[i, j, k] = temp[index++];
                        Console.Write(x[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
            }// i think it's correct code i've changed it
