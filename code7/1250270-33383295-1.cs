    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex == this.dataGridView1.NewRowIndex)
            return;
        //Check if the event is fired for your specific column
        //I suppose LinkColumn is name of your link column
        //You can use e.ColumnIndex == 0 for example, if your link column is first column
        if (e.ColumnIndex == this.dataGridView1.Columns["LinkColumn"].Index)
        {
            e.Value = e.RowIndex + 1;
        }
    }
