        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var dt = dataGridView1.DataSource as DataTable;
                if (dt != null && dt.Rows.Count > e.RowIndex && dt.Columns.Count > e.ColumnIndex)
                {
                    var value = Convert.ToInt32(dt.Rows[e.RowIndex][e.ColumnIndex]);
                    if (value == 0)
                        e.Value = Image.FromFile(@"C:\No.png"); // Here you can provide your own path of No.png image
                    if (value == 1)
                        e.Value = Image.FromFile(@"C:\OK.png"); // Here you can provide your own path of Ok.png image
                }
            }
        }
