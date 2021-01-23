        private void ProfilesGrid_CellContentClick(object sender, [NotNull] DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            int columnCount = dataGridView.Columns.GetColumnCount(DataGridViewElementStates.None) - 1;
            if (e.ColumnIndex != columnCount)
            {
                return;
            }
            dataGridView.EndEdit();
            if (!(bool) dataGridView[e.ColumnIndex, e.RowIndex].Value)
            {
                return;
            }
            foreach (DataGridViewRow row in dataGridView.Rows.Cast<DataGridViewRow>().Where(row => row.Index != e.RowIndex))
            {
                row.Cells[columnCount].Value = false;
            }
        }
