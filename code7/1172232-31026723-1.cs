    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        string currentValue = Convert.ToString(dataGridView1.CurrentCell.Value);
        if (e.ColumnIndex == 0 && !string.IsNullOrEmpty(currentValue))
        {
            Int32.TryParse(currentValue, out _id);
            DataTable dtl = dc.RunQuery(@"SELECT ProductName FROM Product WHERE ProductCode = '" + _id + "'");
            DataRow row = dtl.Rows[0];
            dataGridView1.Rows[e.RowIndex].Cells[1].Value = row[0].ToString();
        }
    }
