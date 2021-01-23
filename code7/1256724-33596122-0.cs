        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Calculated Column")
            {
                var data = (DataObj)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                e.Value = GetCalculatedColumnValue(data);
                e.FormattingApplied = false;
            }   
        }
