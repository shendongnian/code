    private void GetStatusCheckboxes()
    {
        foreach (UltraGridRow row in CVaultGrid.Rows)
        {
            Dictionary<string, bool> statusChecked;
            statusChecked = GetStatusForRow(CVaultDataSource.Band, row);
        
            // Here you should replace the Console.WriteLine with the code 
            // that uses the status of the current indexed row by the foreach
            foreach (KeyValuePair<string, bool> kvp in statusChecked)
                Console.WriteLine("RowIndex=" + row.Index + ", " + 
                                  "Status site:" + kvp.Key + " is " + kvp.Value.ToString());
            Console.WriteLine("\r\n");
       }
    }
