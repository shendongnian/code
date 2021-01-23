        public static bool SearchArray(int soughtOutNum, int[,] searchableArray, out int rowIndex, out int colsIndex)
        {
            rowIndex = -1;
            colsIndex = -1;
            // Assuming your c is column and r is row
            for (int c = 0; c < searchableArray.GetLength(0); c++)
            {
                for (int r = 0; r < searchableArray.GetLength(1); r++)
                {
                    if (searchableArray[r, c] == soughtOutNum)
                    {
                        rowIndex = r;
                        colsIndex = c;
                        //Console.WriteLine("found number");
                        return true;
                    }
                }
            }
            //Console.WriteLine("Number not found");
            return false;
        }
