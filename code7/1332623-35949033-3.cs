    private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        if (e.ColumnIndex == 0 && e.RowIndex == 0)
        {
            e.Cancel = true;
        }
    }
