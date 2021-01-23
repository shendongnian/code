    DataTable dt = new DataTable();
            
                const int numCols = 10;
            int curCol = 4;
            int searchRow = 1;
            int startRow = 3;
            int numRows = 25;
            int hashVal = dt.Rows[searchRow][curCol].GetHashCode();
            var thisValue = dt.Rows[searchRow][curCol];
            //iterate cols and rows
            for(int c = 0; c < numCols; c++)
            {
                for(int r = startRow; r < startRow + numRows; r++)
                {
                    int thisHash = dt.Rows[r][c].GetHashCode();
                    if (thisHash == hashVal)
                    {
                        dt.Rows[r][c] = thisValue;
                    }
                }
            }
