    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        //If this is header row or new row, do nothing
        if (e.RowIndex < 0 || e.RowIndex == this.dataGridView1.NewRowIndex)
            return;
        //If formatting your desired column, set the value
        if (e.ColumnIndex=this.dataGridView1.Columns["LoginButton"].Index)
        {
            //You can put your dynamic logic here and use different values based on cell value
            e.Value = "Login";
        }
    }
