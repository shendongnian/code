    public class Ping : IHttpHandler
    { 
       public void ProcessRequest(HttpContext context)
       {
          context.Response.ContentType = "text/plain";
          context.Response.Write("Ping");
       }
    
       public bool IsReusable { get { return false; }}
    }
