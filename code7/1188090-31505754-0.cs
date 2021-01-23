    public class Handler : IHttpHandler
    {
    
        public void ProcessRequest (HttpContext context)
        {
    
            string ImageId = context.Request.QueryString["Id"]; //you'll want to do defensive coding and make sure this query string variable exists
    
        
    
            byte[] ImageBytes = Database.GetImageBytes(ImageId); //I assume you know how to retrieve the byte array from the database?
            string MimeType = Database.GetMimeType(ImageId);
    
            context.Response.ContentType = MimeType;
            context.Response.BinaryWrite(ImageBytes);
        }
    
        public bool IsReusable { get { return false; } }
    }
