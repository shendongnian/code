    private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
    {
    
        // Check if we are sorting by the special column.
        if (myDataGridView.Columns.Contains("My_Column") && e.Column == myDataGridView.Columns["My_Column"])
        {
        
            // Parse the special values (add validation if required).
            string[] parts1 = e.CellValue1.ToString().Trim().Split('/');
            int a1 = int.Parse(parts1[0].Split(' ')[2]);
            int b1 = int.Parse(parts1[1]);
            int c1 = int.Parse(parts1[2]);
            string[] parts2 = e.CellValue2.ToString().Trim().Split('/');
            int a2 = int.Parse(parts2[0].Split(' ')[2]);
            int b2 = int.Parse(parts2[1]);
            int c2 = int.Parse(parts2[2]);
            
            // Compare each value as required.
            
            // First compare the last value (year?)
            e.SortResult = c1.CompareTo(c2);
            
            // If equal, then compare second value (month?)
            if(e.SortResult == 0)
                e.SortResult = b1.CompareTo(b2);
            
            // Finally if still equal, then compare first value
            if(e.SortResult == 0)
                e.SortResult = a1.CompareTo(a2);
        
        }
    
    }
