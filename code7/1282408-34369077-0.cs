     public  void ExportToExcel(DataTable dt)
    {
        
        XLWorkbook wb = new XLWorkbook();
        //Specify sheet name
        var ws = wb.Worksheets.Add(dt, "SHEET NAME");
        ws.Columns().AdjustToContents();
        ws.Style.Fill.BackgroundColor = XLColor.Transparent;
        var excelTable = ws.Tables.First();
        excelTable.ShowAutoFilter = false;
        excelTable.ShowRowStripes = false;
        excelTable.Theme = XLTableTheme.None;
        excelTable.Style.Border.TopBorder = XLBorderStyleValues.Thin;
        excelTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        excelTable.Style.Border.RightBorder = XLBorderStyleValues.Thin;
        excelTable.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
        var headerRow = ws.Tables.First().FirstRow();
        headerRow.Style.Fill.BackgroundColor = XLColor.Transparent;
        headerRow.Style.Font.Bold = true;
	//specify filename
        string fileName = "File Name"  + ".xlsx";
        HttpResponse httpResponse = Response;
        httpResponse.Clear();
        httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        httpResponse.AddHeader("content-disposition", "attachment;filename=\"" + fileName + "\"");
        // Flush the workbook to the Response.OutputStream
        using (MemoryStream memoryStream = new MemoryStream())
        {
            wb.SaveAs(memoryStream);
            memoryStream.WriteTo(httpResponse.OutputStream);
            memoryStream.Close();
        }
        httpResponse.End();
    }
