    private void dataGridView1_EditingControlShowing(object sender, 
                 DataGridViewEditingControlShowingEventArgs e)
    {
        DataGridViewCell cell = dataGridView1.CurrentCell;
        editMBox.Parent = dataGridView1;
        editMBox.Location = dataGridView1.GetCellDisplayRectangle(cell.ColumnIndex, 
                                      cell.RowIndex, false).Location;
        editMBox.Size = editBox.Size;
        editMBox.Show();
        editMBox.Mask = yourMask;
        editMBox.BringToFront();
    }
      
