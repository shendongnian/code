        if (context.Request.InputStream != null && context.Request.InputStream.Length > 0)
        {
            System.IO.Stream fileContent = context.Request.InputStream;
            System.IO.FileStream fileStream = System.IO.File.Create(Server.MapPath("~/") + fileName);
            fileContent.Seek(0, System.IO.SeekOrigin.Begin);
            fileContent.CopyTo(fileStream);
        }
