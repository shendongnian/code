    public class DownloadPdf : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string filePath = Uri.UnescapeDataString(context.Request.QueryString["file"]);
            string contentType = Uri.UnescapeDataString(context.Request.QueryString["type"]);
            context.Response.ContentType = contentType;
            context.Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + Path.GetFileName(filePath));
            context.Response.ContentType = "application/pdf";
            context.Response.WriteFile(filePath);
            context.Response.End();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
