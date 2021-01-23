        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn &&
                e.RowIndex >= 0)
            {
                var nextRowNum = senderGrid.Rows[e.RowIndex] + 1;
                // do what you need with the custId cell/value
                // i.e. select that row and hilite it etc
            }
        }
