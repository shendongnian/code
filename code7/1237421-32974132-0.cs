            private static void Print(int[,] matrix, int num)
        {
            Random random = new Random();
            int R = matrix.GetLength(0);
            int K = matrix.GetLength(1);
            for (int h = 0; h < R; h++)
            {
                for (int k = 0; k < K; k++)
                {
                    if(matrix[h, k] == num)
                         Console.Write("{0,1}", h,k);
                }
                Console.WriteLine();
            }
        }
