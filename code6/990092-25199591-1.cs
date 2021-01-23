    public class YourHandler: IHttpHandler {
        public void ProcessRequest(HttpContext ctx){
            StringWriter writer = new StringWriter();
            ctx.Server.Execute("~/UserControl.ascx", output, false);
            ctx.Response.Write(writer);
        } 
    }
