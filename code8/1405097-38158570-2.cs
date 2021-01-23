    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        //Use zero based index of the cell that contains categories
        var cell= 3;
        if (e.ColumnIndex == cell && e.RowIndex >= 0)
        {
            var categories = (List<object>)dataGridView1.Rows[e.RowIndex].Cells[cell].Value;
            e.Value = string.Join(", ", categories.Select(x => x.ToString()));
        }
    }
