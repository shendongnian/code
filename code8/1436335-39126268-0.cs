    ExcelPackage package = new ExcelPackage();
    ExcelWorksheet ws = package.Workbook.Worksheets[1];
    //header
    ws.Cells[1, 1].Value = "Column1";
    ws.Cells[1, 2].Value = "Column2";
    ws.Cells[1, 3].Value = "Column3";
    ws.Cells[1, 4].Value = "Column4";
    ws.Cells[1, 5].Value = "Column5";
    //content
    int i = 1;
    foreach (Item item in list)
    {
        i++;
        ws.Cells[i, 1].Value = item.Prop1;
        ws.Cells[i, 2].Value = item.Prop2;
        // format datetime
        ws.Cells[i, 3].Value = item.Prop3.ToString("yyyy-MM-dd");
        ws.Cells[i, 4].Value = item.Prop4;
        ws.Cells[i, 5].Value = item.Prop5;
    }
    using (var memoryStream = new MemoryStream())
    {
        response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        response.AddHeader("content-disposition", $"attachment; filename=Filename.xlsx");
        package.SaveAs(memoryStream);
        memoryStream.WriteTo(response.OutputStream);
        response.Flush();
        response.End();
    }
