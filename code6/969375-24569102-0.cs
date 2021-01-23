      Response.Clear();
      Response.AddHeader("content-disposition", "attachment;filename=download.xlsx");
      Response.Charset = "";
      Response.Cache.SetCacheability(HttpCacheability.NoCache);
      Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
      content.CopyTo(context.Response.OutputStream); //content is the file stream
      Response.End();
