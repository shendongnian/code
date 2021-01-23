    private void DataGridView01_CellClick(object sender,DataGridViewCellEventArgs e)
    {
    if (DataGridView01.Rows.Count > -1)
    {
    PersonIdTextBox.Text=DataGridView01.Rows[e.RowIndex].Cells[0].Value.ToString();
    comboBox1.Text = DataGridView01.Rows[e.RowIndex].Cells[1].Value.ToString();
    Txt_FirstName.Text = DataGridView01.Rows[e.RowIndex].Cells[2].Value.ToString();
     mIDDLENAMETextBox.Text = DataGridView01.Rows[e.RowIndex].Cells[3].Value.ToString();
    sURNAMETextBox.Text = DataGridView01.Rows[e.RowIndex].Cells[4].Value.ToString();
    cITYTextBox.Text = DataGridView01.Rows[e.RowIndex].Cells[5].Value.ToString();
    eMAILTextBox.Text = DataGridView01.Rows[e.RowIndex].Cells[6].Value.ToString();
    }
    }
