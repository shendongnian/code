        FileInfo templateFile = new FileInfo(@"D:\DOTNET\navigatetest.xlsm");
        FileInfo newFile = new FileInfo(@"D:\DOTNET\navigatetest11.xlsm");
        if (newFile.Exists)
        {
            newFile.Delete();
            newFile = new FileInfo(@"D:\DOTNET\navigatetest11.xlsm");
        }
        using (ExcelPackage package = new ExcelPackage(newFile, templateFile))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
            String ConnectionString = "SERVER=localhost;DATABASE=excelmaps;UID=root;PASSWORD=;";
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("Select * FROM `sheet1`", connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            DataRow row1 = dt.NewRow();
            worksheet.Cells["A1"].LoadFromDataTable(dt, true);       
            package.Save();
     }
            
