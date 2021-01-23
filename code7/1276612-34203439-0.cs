    private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        Color active = Color.LightGreen;
        Color inactive = Color.LightPink;
    
        DataRowView drv = bindingSource[e.RowIndex] as DataRowView;
    
        bool expired =
            DateTime.Parse(drv["ExpirationDate"].ToString()) < DateTime.Today;
    
        if (expired)
        {
            grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = inactive;
        }
        else
        {
            grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = active;
        }
    
    } 
   
