    try {
        var pck = new OfficeOpenXml.ExcelPackage();
        var ws = pck.Workbook.Worksheets.Add("Sheet-Name");
        ws.Cells["A2"].LoadFromDataTable(tbl, false);
        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;  filename=FileName.xlsx");
        Response.BinaryWrite(pck.GetAsByteArray());
    } catch (Exception ex) {
        //log error
    }
    Response.End();
