    void Write(XLWorkbook workbook, string bookName) {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        HttpContext.Current.Response.AddHeader("content-disposition", String.Format(@"attachment;filename={0}.xlsx", bookName.Replace(" ", "_")));
    
        using (MemoryStream memStream = new MemoryStream())
        {
            workbook.SaveAs(memStream);
            memStream.WriteTo(HttpContext.Current.Response.OutputStream);
            memStream.Close();
        }
        HttpContext.Current.Response.End();
    }
