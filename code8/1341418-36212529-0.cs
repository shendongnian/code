     for (int i = 0; i < dtGrid.Columns.Count; i++)
     {
         for (int k = 0; k < dtGrid.Rows.Count; k++)
         {
             // ??
             avgList.Add(Convert.ToDouble(dtGrid.Rows[k][i].ToString()));
         }
     }
