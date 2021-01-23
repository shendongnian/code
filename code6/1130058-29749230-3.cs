    private void Gridview_Output_CellEndEdit(object sender, DataGridViewCellEventArgs e)
       {
           DataGridViewCell cell = Gridview_Output[e.ColumnIndex, e.RowIndex];
           if (cell.Value.ToString() != originalValue)
           {
               cell.Style.BackColor = Color.Red;
           }                
       }
