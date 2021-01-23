    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
        if(cell.Value == null) return;
        // say this is for example: £123.40
        var ukCulture = new System.Globalization.CultureInfo("en-GB");
        decimal value;
        if (decimal.TryParse(cell.Value.ToString(), NumberStyles.Any, ukCulture, out value))
        {
            cell.Value = (-1*value).ToString("C", ukCulture);
        }
    }
