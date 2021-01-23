      Private DG_CellValueChanged(Object sender , DataGridViewCellEventArgs e)
        {
        if(e.RowIndex.equls(-1))
           {
             return;
           }
        if(e.ColumnIndex.Equls(0))
          {    if(e.RowIndex.equls(-1))
               {
                 return;
               }
            if(e.ColumnIndex.Equls(0))
              {
                string sVal=//Your Calculation  
                DG.Rows[e.RowIndex].Cell[1].value=sVal;
              }
            }
