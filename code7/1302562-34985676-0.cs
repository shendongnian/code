     private void cellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Only handles cases where the cell contains a TextBox
            var editedTextbox = e.EditingElement as TextBox;
    
            if (editedTextbox != null)
              {                
                 //your logic of quntity
                 grid2.rows.add();
                 grid2.rows[grdi.rowcount-1].cell["Cell Name"].value=qty;
              }
        }
