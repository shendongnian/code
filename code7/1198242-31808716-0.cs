    private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e) {
        //Suppose your interested column has index 1
        if (e.Column.Index == 1){
           e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
           e.Handled = true;//pass by the default sorting
         }
    }
