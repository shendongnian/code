     private DataView ConvertFromMatrixToDataTable(Point[,] matrix)
        {
            var myDataTable = new DataTable();            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                myDataTable.Columns.Add(i.ToString());
            }
            for (int j = 0; j < matrix.GetLength(1); j++)
            {                
                var row = myDataTable.NewRow();
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    row[i] = matrix[i, j];
                }
                
                myDataTable.Rows.Add(row);
            }
            return myDataTable.DefaultView;
        }
