    private static void SiteBlanks() {
        try {
            MutableDataTable dt = DataTable.New.ReadCsv(@"C:\temp.csv");
            string columnName = "Site";
            for (int i = 0; i <= dt.Rows.Count; i++) {
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
 
