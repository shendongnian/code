    public class UploadHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    string fname = context.Server.MapPath("uploads\\" + file.FileName);
                    file.SaveAs(fname);
                    // Do something with the file if you want
                }
                context.Response.Write("File/s uploaded successfully");
            }
            else
                context.Response.Write("No files uploaded");
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
