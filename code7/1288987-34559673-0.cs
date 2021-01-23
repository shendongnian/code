    public static int[] RowSums(int[,] arr2D)
            {
                //declare variables
                int[] sums = new int[arr2D.GetLength(0)];
                //loop through array rows
                for (int row = 0; row < arr2D.GetLength(0); ++row)
                {
                    for (int col = 0; col < arr2D.GetLength(1); ++col)
                    {
                        sums[row] += arr2D[row, col];
                    }
                } //end foreach
                return sums;
            }
