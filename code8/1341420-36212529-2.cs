     List<List<double>> perColumnAvg = new List<List<double>>();
     for (int i = 0; i < dtGrid.Columns.Count; i++)
     {
         avgList = new List<double>();
         for (int k = 0; k < dtGrid.Rows.Count; k++)
         {
             // ??
             avgList.Add(Convert.ToDouble(dtGrid.Rows[k][i].ToString()));
         }
         perColumnAvg.Add(avgList);
     }
