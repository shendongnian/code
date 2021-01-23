    foreach (var cs in new string[] {
        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES';",
        "OLEDB;Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0; HDR = Yes; IMEX = 1';" })
        try { using (var con = new System.Data.OleDb.OleDbConnection(cs)) con.Open(); MessageBox.Show(cs + " worked bro!!"); } catch { }
    foreach (var cs in new string[] {
        "Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};DBQ=" + filePath + ";",
        "Driver={Microsoft Excel Driver (*.xls)};DriverId=790;Dbq=" + filePath + ";",
        "Driver={Microsoft Excel Driver (*.xls)};Dbq=" + filePath + ";ReadOnly=0;"})
        try { using (var con = new System.Data.Odbc.OdbcConnection(cs)) con.Open(); MessageBox.Show(cs + " worked bro!!"); } catch { }
