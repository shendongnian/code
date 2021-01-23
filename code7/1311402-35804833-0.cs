        public static void outputFile(FileContentResult file, String contentDisposition)
        {
            var context = System.Web.HttpContext.Current;
            file.FileDownloadName = contentDisposition;
            context.Response.Clear();
            context.Response.ClearContent();
            context.Response.ClearHeaders();
            context.Response.AppendHeader("content-disposition", contentDisposition);
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.ContentType = file.ContentType;
            context.Response.AppendHeader("content-length", file.FileContents.Length.ToString());
            context.Response.BinaryWrite(buffer: file.FileContents.ToArray());
            context.Response.Flush();
            context.ApplicationInstance.CompleteRequest();
        }
