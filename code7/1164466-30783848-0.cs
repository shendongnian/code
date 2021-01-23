    public class Handler1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            // set from QueryString
            string filePath = "...";
            FileInfo myfile = new FileInfo(filePath);
            // Checking if file exists
            if (myfile.Exists)
            {
                // Clear the content of the response
                context.Response.ClearContent();
                // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);
                // Add the file size into the response header
                context.Response.AddHeader("Content-Length", myfile.Length.ToString());
                // Set the ContentType
                context.Response.ContentType = "application/octet-stream";
                context.Response.TransmitFile(filePath);
                context.Response.Flush();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                try
                {
                    myfile.Delete();
                }
                catch (IOException)
                { }
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
