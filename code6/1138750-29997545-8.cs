    page.Response.Clear();
    page.Response.ContentType = result.MimeType;
    page.Response.Cache.SetCacheability(HttpCacheability.Private);
    page.Response.Expires = -1;
    page.Response.Buffer = true;
    page.Response.BinaryWrite(result.DocumentBytes);
    page.Response.End();
