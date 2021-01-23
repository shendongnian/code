    private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
    {
        //This will indicate the end of the cell edit (checkbox checked)
        if (e.ColumnIndex == dataGridView1.Columns[0].Index &&
            e.RowIndex != -1)
        {
            dataGridView1.EndEdit();
        }
    }
    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == dataGridView1.Columns[0].Index && 
            e.RowIndex != -1)
        {
            //Handle your checkbox state change here
            DataTable a = tablebill();
            bool checkBoxValue = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            if (checkBoxValue == true)
            {
                a.Rows.Add(dataGridView1.Rows[e.RowIndex].Cells["Products"].Value);
            }
            else { }
            dataGridView1.DataSource = a;
        }
    }
