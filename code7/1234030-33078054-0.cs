    public class DownloadFile : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string fileName = @"test.txt";
            string filePath = context.Server.MapPath("/test.txt");
            string logFilePath = context.Server.MapPath("/Log.txt");
            //string filePath = Uri.UnescapeDataString(context.Request.QueryString["file"]);
            //string fileName = Path.GetFileName(filePath);
            Singleton s = Singleton.Instance;
            s.isFileDownload = Convert.ToBoolean(context.Request.Form["isFileDownload"]);
            if (context.Response.IsClientConnected) //Shouldn't this tell me if the client is connected or not?
            {
                
                using (var writer = new StreamWriter(logFilePath,true))
                {
                    if (!File.Exists(logFilePath))
                    {
                        //Create log file if one does not exist
                        File.Create(logFilePath);
                    }
                    else
                    {
                        writer.WriteLine("The following file was downloaded \"{0}\" on {1}", fileName, DateTime.Now.ToString("dd/MM/yyyy") + " at " + DateTime.Now.ToString("HH:mm:ss"));
                        writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    }
                }
            }
            //To mock the large file download
            if (s.isFileDownload)
            System.Threading.Thread.Sleep(10000);
            if (context.Response.IsClientConnected )
            {
                if (s.isFileDownload){
                System.Threading.Thread.Sleep(100);
                context.Response.ContentType = "application/octet-stream";
                context.Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + Path.GetFileName(filePath));
                context.Response.WriteFile(filePath);
                context.Response.OutputStream.Flush();
                context.Response.End();
            }
                else
                {
                    return;
                }
            }
            else
            {
                return;
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
