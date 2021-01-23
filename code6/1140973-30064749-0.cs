    using (ExcelPackage package = new ExcelPackage())
    {
        ExcelWorksheet ws = package.Workbook.Worksheets.Add("Data");
        ws.Cells[1, namecol].Value = "Name";
        ws.Cells[1, cellcol].Value = "Cell No";
        ws.Cells[1, emailcol].Value = "Email";
        ws.Cells[1, citycol].Value = "City";
        ws.Cells[1, categorycol].Value = "Category";
        SqlCeDataReader reader = null;
        conn.Open(); //open the connection
        SqlCeCommand selecectnumberscmd = new SqlCeCommand(selectgroup, conn);
        reader = selecectnumberscmd.ExecuteReader();
        int i = 1;
        while (reader.Read())
        {
            ws.Cells[i, namecol].Value = reader.GetString(1);
            ws.Cells[i, cellcol].Value = reader.GetInt64(2);
            ws.Cells[i, emailcol].Value = reader.GetString(3); ;
            ws.Cells[i, citycol].Value = reader.GetString(4);
            ws.Cells[i, categorycol].Value = reader.GetString(5);
            i++;
        }
        conn.Close();
        //Now you have options to export the file - just save someplace, get a byte array or get a reference to the output stream etc with some of the following:
        package.SaveAs(someFilePathString);
        someByteArrayVariable =  package.GetAsByteArray();
        package.Stream;
    }
