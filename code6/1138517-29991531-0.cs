        DataTable DT_Excel = new DataTable();
        DT_Excel.Load(DbDataReader);
        //Load data into a DataTable
        DataTable DT_DataBase = new DataTable();
        DT_DataBase = GetDataFromDatabase();
        //A simple loop to compare the data
        foreach (DataRow dtRow in DT_Excel.Rows) {
                DT_DataBase.DefaultView.RowFilter = "ID = " + dtRow.Item("ID");
                if (DT_DataBase.DefaultView.ToTable.Rows.Count > 0) {
                        //Do something if record is already in the databse
        }
