    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
    
        if (e.ColumnIndex == 0 && e.RowIndex != this.dataGridView1.NewRowIndex)
        {
            double d = double.Parse(e.Value.ToString());
            e.Value = d.ToString("0");
        }
        else
        {
            if (e.ColumnIndex == 2 && e.RowIndex == this.dataGridView1.NewRowIndex)
            {
                double precio = Convert.ToDouble("0");
                dataGridView1["Column7", e.RowIndex].Value = (precio.ToString());
            }
        }
    }
