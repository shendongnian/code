    private void CustomSortCompare(object sender, DataGridViewSortCompareEventArgs e)
    {
        var a = int.Parse(e.CellValue1.ToString());
        var b = int.Parse(e.CellValue2.ToString());
    
        // If the cell value is already an integer, just cast it instead of parsing    
        e.SortResult = a.CompareTo(b);    
        e.Handled = true;
    }
