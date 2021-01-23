    var col7 = new DataGridViewButtonColumn
        {
            HeaderText = "Proceed", Name = "Action", 
            Text = "+",
            UseColumnTextForButtonValue = true
        };
    dgSSW.Columns.Add(col7);
    dgSSW.CellContentClick += GridCellContentClick; 
    private void GridCellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (dgSSW.Columns[e.ColumnIndex].Name == "Action")
        {
            MessageBox.Show((e.RowIndex + 1).ToString());
        }
    }
