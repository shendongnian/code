    HttpContext.Current.Response.Clear();
    HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");
    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" + fileName + ".pdf");
    HttpContext.Current.Response.BinaryWrite(bytes);
    HttpContext.Current.Response.End();
