        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null && dataGridView1.Columns[e.ColumnIndex].Name == "Image")
            {
                dataGridView1.Rows[e.RowIndex].Visible = false;
            }
        }
