    DataTable dt = Conversao.ConvertTo(list);
    if (dt == null || dt.Columns.Count == 0)
        throw new Exception("ExportToExcel: Null or empty input table!\n");
    OfficeOpenXml.ExcelPackage excel = new ExcelPackage();
    ExcelWorksheet worksheet = excel.Workbook.Worksheets.Add("Plan 1");
    worksheet.Cells["A1"].LoadFromDataTable(dt, true);
    for (var i = 0; i < dt.Columns.Count; i++)
    {
        if (dt.Columns[i].DataType == System.Type.GetType("System.DateTime"))
        {
            worksheet.Column(i + 1).Style.Numberformat.Format = "dd/mm/yyyy hh:mm:ss";
        }
    }
    Response.Clear();
    Response.AddHeader("content-disposition", "attachment;filename=rel.xlsx");
    Response.ContentType = "application/vnd.ms-excel";
    Response.ContentEncoding = System.Text.Encoding.Default;
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    System.IO.MemoryStream stream = new System.IO.MemoryStream();
    excel.SaveAs(stream);
    stream.WriteTo(Response.OutputStream);
    Response.End();
