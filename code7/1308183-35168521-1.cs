           System.Web.HttpContext context = System.Web.HttpContext.Current;
           context.Response.Clear();
           context.Response.ClearHeaders();
           context.Response.ClearContent();
           context.Response.AppendHeader("content-length", fileBytes.Length.ToString());
           context.Response.ContentType = GetMimeTypeByFileName(sFileName);
           context.Response.AppendHeader("content-disposition", Convert.ToString("attachment; filename=") + sFileName);
           context.Response.BinaryWrite(ReadWholeArray(FullFilePath));
