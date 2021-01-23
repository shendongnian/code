     for (int i = 0; i <dtbl.Columns.Count; j++)
     {
         //A cell with width 1000.
         sringTableRtf.Append(@"\cellx" + ((i+1) * 1000).ToString());
         if (i == 0)
         sringTableRtf.Append(@"\intbl  " + dtbl.Columns[i].ColumnName);
         else
         sringTableRtf.Append(@"\cell   " + dtbl.Columns[i].ColumnName);
      }
