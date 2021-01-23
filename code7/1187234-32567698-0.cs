    public ActionResult XLSX()
    {
      System.IO.Stream spreadsheetStream = new System.IO.MemoryStream();
      XLWorkbook workbook = new XLWorkbook();
      IXLWorksheet worksheet = workbook.Worksheets.Add("GradientFillExample");
      worksheet.Cell(1, 1).SetValue("example").Style.Fill.SetBackgroundColor(XLColor.FromHtml("#08F47B")); // use some unique color
      workbook.SaveAs(spreadsheetStream);
