    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        var senderGrid = (DataGridView)sender;
        if (e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
        {
            var cellValues = Enumerable.Range(0, senderGrid.Columns.Count)
                                       .Select(i => senderGrid[i, e.RowIndex].Value);
            string text = String.Join("; ", cellValues);
            MessageBox.Show(text);
            var rw = senderGrid.Rows[e.RowIndex].DataBoundItem as DataRowView;
            text = String.Join("; ", rw.Row.ItemArray);
            MessageBox.Show(text);
        }
    }
