    MemoryStream memoryStream = new MemoryStream();
    renderedReport.ExportDocument(StiExportFormat.Excel2007, memoryStream, exportSettings);
    
    HttpContext.Current.Response.Clear();
    HttpContext.Current.Response.ContentType = "text/csv";
    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Emad.xlsx");
    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
    HttpContext.Current.Response.BinaryWrite(memoryStream.ToArray());
    HttpContext.Current.Response.End();
