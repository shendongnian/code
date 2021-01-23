    byte[] bytes = memoryStream.ToArray();
    Response.Clear();
    Response.ContentType = "application/pdf";
    Response.AddHeader("Content-Disposition", "attachment;filename=ControleDePonto.pdf");
    Response.Buffer = true;
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Response.BinaryWrite(bytes);
    Response.End();
