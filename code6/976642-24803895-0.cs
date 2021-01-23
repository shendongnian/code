    public class TData : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            switch (context.Request["method"])
            {
                case "test":
                    Test(context);
                    break;
                //other methods
                default:
                    throw new ArgumentException("unknown method");
            }
        }
    
        public void Test(HttpContext context)
        {
            // Those parameters are sent by the plugin
            var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
            //more code...
    
            context.Response.Write(String.Format("Hello {0}!", blabla));
        }
    }
