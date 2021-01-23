     for (int i = 0; i <dtbl.Columns.Count; j++)
     {
         //A cell with width 1000. 
         tableRtf.Append(@"\cellx" + ((i+1) * 1000).ToString());
         if (i == 0)
         tableRtf.Append(@"\intbl  " + dtbl.Columns[i].ColumnName);
         else
         tableRtf.Append(@"\cell   " + dtbl.Columns[i].ColumnName);
      }
