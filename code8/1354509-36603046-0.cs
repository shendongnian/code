        private void dt_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == -1)
            {
                // get text
                string msg = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                // Get mouse position relative to the grid
                var relativeMousePosition = dt.PointToClient(Cursor.Position);
                // Show the tooltip
                this.toolTip1.Show(msg, dt, relativeMousePosition);
            }
        }
