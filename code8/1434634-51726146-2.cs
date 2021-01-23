        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            int so = 1;
            if (dataGridView1.SortOrder == SortOrder.Ascending)
            {
                so = -1;
            }
            if (e.RowIndex1 == 0 )
            {
                e.SortResult = so;
                e.Handled = true;
            }
            if (e.RowIndex2 == 0)
            {
                e.SortResult = -so;
                e.Handled = true;
            }
        }
