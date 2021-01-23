        private void btnLoadArray_Click(object sender, EventArgs e)
        {
            for (int r = 0; r < intTable.GetLength(0); r++)
            {
                for (int c = 0; c < intTable.GetLength(1); c++)
                {
                    int intResult = (r + 1) * (c + 1);
                    intTable[r, c] = intResult;
                }
            }
        }
