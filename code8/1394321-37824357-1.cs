     foreach (string Csv in csvDataList)
     {
         DataRow dRow = dt.NewRow();
         int i = 0;
         foreach (string cell in Csv.Split(','))
         {
               if (dRow[i].GetType() == typeof(int))
               {
                   int cellValue = 0;
                   if (Int32.TryParse(cell, out cellValue))
                   {
                      dRow[i++] = cellValue;
                   }
                }
                else if (dRow[i].GetType() == typeof(char) && cell.Length == 1)
                {
                    dRow[i++] = cell[0];
                }
                else
                    dRow[i++] = cell;
         }
         dt.Rows.Add(dRow);
     }
