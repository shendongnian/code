      private boolean IsRowOrCellSelected()
      {
        if (PTable.SelectedRows.Count > 0)
        {
            DataGridViewRow currentRow = PTable.SelectedRows[0];
            if (currentRow.Cells.Count > 0) 
            {      
                bool rowIsEmpty = true;    
                foreach(DataGridViewCell cell in currentRow.Cells)    
                {
                   if(cell.Value != null) 
                   { 
                      rowIsEmpty = false;
                      break;
                   }    
                }
           }
          if(rowIsEmpty)
               return false;
          else
              return true;
       }
