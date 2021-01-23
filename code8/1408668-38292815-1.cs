    using System.IO;
    using System.Web;
    
    namespace WebApplication1
    {
        public class LotteryHandler : IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
                context.Response.ContentType = "application/json";
    
                using (var reader = new StreamReader(context.Request.InputStream))
                {
                    string values = reader.ReadToEnd();
    
                    //Use Newtonsoft to deserialize to Lottery type
    
                    //do whatever with Lottery
    
                    //Use Newtonsoft to serialize Lottery again (or whatever you want to return)
    
                    context.Response.Write(your_serialized_object);
    
                    //finish the response
                    context.Response.Flush();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
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
    }
