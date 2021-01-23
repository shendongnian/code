    try {
        var pck = new OfficeOpenXml.ExcelPackage();
        var ws = pck.Workbook.Worksheets.Add("Sheet-Name");
        ws.Cells["A1"].LoadFromDataTable(ds.Tables[0], true, TableStyles.Light18);
        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
        Response.BinaryWrite(pck.GetAsByteArray());
    } catch (Exception ex) {
        //log error
    }
    Response.End();
