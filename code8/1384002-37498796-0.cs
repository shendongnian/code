    private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dataGridView1.Columns[e.ColumnIndex].Name == "COLUMNNAME")
        {
            e.Value = Path.GetExtension(e.Value.ToString());
        }
    }
