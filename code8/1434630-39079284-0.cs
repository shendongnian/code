    private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
    {
        if (e.RowIndex1 == 0)
        {
            e.Handled = true;
        }
        else
        {
            e.Handled = false;
        }
    }
