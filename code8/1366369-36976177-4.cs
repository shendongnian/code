    public class GetDelivery : IHttpHandler
        {
    
            public void ProcessRequest(HttpContext context)
            {
                
                
                var jsonSerializer = new JavaScriptSerializer();
    
                var jsonString = string.Empty;
    
                context.Request.InputStream.Position = 0;
                using (var inputStream = new StreamReader(context.Request.InputStream))
                {
                    jsonString = inputStream.ReadToEnd();
                }
    
                var data = new List<Response>();
                data = jsonSerializer.Deserialize<List<Response>>(jsonString);
    
    
                //Modification and Saving Data
    
                context.Response.Write("OK");
    
            }
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }
