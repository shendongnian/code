    public void ProcessRequest(HttpContext context)
    {
        var jsonSerializer = new JavaScriptSerializer();
        var jsonString = String.Empty;
    
        context.Request.InputStream.Position = 0;
        using (var inputStream = new StreamReader(context.Request.InputStream))
        {
            jsonString = inputStream.ReadToEnd();
        }
    
        var workItem = jsonSerializer.Deserialize<List<WorkItem>>(jsonString);
        if(workItem != null && do your check for security token)
        {
                context.Response.ContentType = "application/download";
                context.Response.ContentEncoding = Encoding.UTF8;
                context.Response.AddHeader("Content-Disposition",
                    "attachment; filename=" + HttpUtility.UrlEncode("FileName", Encoding.UTF8)); //return FileName from DB
                context.Response.AddHeader("Content-Length", "Length"); //return Length from DB
                context.Response.Charset = "UTF8";
                context.Response.BinaryWrite(new byte[]{}); //return binary from DB
                context.Response.Write();
                context.Response.Flush();
        }
    }
    
    public class WorkItem
    {
        public string Field { get; set; }
        public string SecurityToken { get; set; }
    }
