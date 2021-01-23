    public static void ExportToExcel(IEnumerable<dynamic> data, string sheetName)
    {
      /****** YOUR ORIGINAL CODE *******/
        gridExcel.HeaderRow.BackColor = System.Drawing.Color.FromArgb(0, 255, 255, 204);
        gridExcel.HeaderRow.Font.Bold = false;
        gridExcel.HeaderRow.Height = Unit.Pixel(30);
        StringWriter sw = new StringWriter();
        gridExcel.RenderControl(new HtmlTextWriter(sw));
        string renderedGridView = sw.ToString();
        //filename will be like xyz.xls
        System.IO.File.WriteAllText(@filename, renderedGridView);
        /**************** Set it accordingly by below reference ****************************/
        XLWorkbook wb = new XLWorkbook();
        var ws = wb.Worksheets.Add(sheetName);
        ws.Cell(2, 1).InsertTable(data);
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        HttpContext.Current.Response.AddHeader("content-disposition", String.Format(@"attachment;filename={0}.xlsx", sheetName.Replace(" ", "_")));
        using (MemoryStream memoryStream = new MemoryStream())
        {
            wb.SaveAs(memoryStream);
            memoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
            memoryStream.Close();
        }
        HttpContext.Current.Response.End();
    }
