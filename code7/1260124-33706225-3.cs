        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0) //To handling files
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    if ((files[i].ContentLength < 500000) && (files[i].ContentType == "image/jpeg"))
                    {
                        HttpPostedFile file = files[i];
                        string fname = context.Server.MapPath("~/Images/" + file.FileName);
                        file.SaveAs(fname);
                    }
                }
                context.Response.ContentType = "text/plain";
                context.Response.Write("File Uploaded Successfully!");
            }
            if (!string.IsNullOrEmpty(context.Request["information"])) //To handeling JSON
            {
                string JSON = context.Request["information"]; //JSON String
            }
        }
