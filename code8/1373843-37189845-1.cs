    private static void SiteBlanks() {
        try {
            MutableDataTable dt = DataTable.New.ReadCsv(@"C:\temp.csv");
            string columnName = "Site";
            var numberOfRows = dt.Rows.Count;
            for (int i = 0; i < numberOfRows; i++) {
                var row = dt.GetRow(i);
                if (string.IsNullOrEmpty(row[columnName].ToString())) {
                    row[columnName] = "No Box";
                }
            }
            dt.SaveCSV(@"C:\temp.csv"); // Save file after changes.
        } catch (Exception ex) {
            //Set Error message
            Error("ERROR: SiteBlanks()", ex);
        }
    }
 
