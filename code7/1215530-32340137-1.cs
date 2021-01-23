    public class MyAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionContext actionContext)
        {
            string rawRequest;
            using (var stream = new StreamReader(actionContext.Request.Content.ReadAsStreamAsync().Result))
            {
                stream.BaseStream.Position = 0;
                rawRequest = stream.ReadToEnd();
            }
        }
    }
