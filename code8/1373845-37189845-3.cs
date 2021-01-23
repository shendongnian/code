    private static void SiteBlanks() {
        try {
            string filePath = @"C:\temp.csv";
            MutableDataTable dt = DataTable.New.ReadCsv(filePath);
            string columnName = "Site";         
            var numberOfRows = dt.NumRows ;
            for (int i = 0; i < numberOfRows; i++) {
                var row = dt.GetRow(i);
                if (string.IsNullOrEmpty(row[columnName])) {
                    row[columnName] = "No Box";
                }
            }
            dt.SaveCSV(filePath);
        } catch (Exception ex) {
            //Set Error message
            Error("ERROR: SiteBlanks()", ex);
        }
    }
 
