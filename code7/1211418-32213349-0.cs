    private void dataGridView1_CellFormatting(object sender,
        DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Value = Convert.ToInt32(e.Value.ToString()) * 2000 // apply     formating here
                e.FormattingApplied = true;
            }
            //repeat for additional columns
         }
