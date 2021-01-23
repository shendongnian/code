            var tmpMatrix = new List<matrix>();
            for (int k = 0; k < tmpRows.Count; k++)
            {
                for (int j = 0; j < tmpCols.Count; j++)
                {
                    int ident = k*tmpCols.Count + j;
                    tmpMatrix.Add(new matrix() { id = ident.ToString(), col = tmpCols[j], row = tmpRows[k] });
                }
            }
