        public static void DownloadFil(string fuldFilNavn)
        {
            HttpContext context = HttpContext.Current;
            context.Response.ClearHeaders();
            context.Response.ClearContent();
            string filNavn = Uri.EscapeDataString(Path.GetFileName(fuldFilNavn)).Replace("+", "%20");
            context.Response.AppendHeader("Content-Disposition", "attachment;filename*=utf-8''" + filNavn);
            context.Response.AppendHeader("Last-Modified", File.GetLastWriteTimeUtc(fuldFilNavn).ToString("R"));
            context.Response.ContentType = "application/octet-stream";
            context.Response.AppendHeader("Content-Length", new FileInfo(fuldFilNavn).Length.ToString());
            context.Response.TransmitFile(fuldFilNavn);
            context.Response.End();
        }
