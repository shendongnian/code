    while(excelReader.Read())
    {
        int i = excelReader.GetInt32(0); // 0 is the column index in your result set
        string text = excelReader.IsDbNull(1) ? string.Empty : excelReader.GetString(1);
        // etc...
    }
