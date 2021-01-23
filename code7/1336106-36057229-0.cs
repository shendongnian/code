    public class CustomActionSelector : ApiControllerActionSelector, IHttpActionSelector
    {
        public new HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            var context = HttpContext.Current;
    
            // Read the content. Probably a better way of doing it?
            var stream = new StreamReader(context.Request.InputStream);
            var input = stream.ReadToEnd();
    
            var array = new JavaScriptSerializer().Deserialize<List<string>>(input);
            if (array != null)
            {
                // It's an array
                //TODO: Choose action.
            }
            else
            {
                // It's not an array
                //TODO: Choose action.
            }
    
            // Default.
            var action = base.SelectAction(controllerContext);
            return action;
        }
    
        public override ILookup<string, HttpActionDescriptor> GetActionMapping(HttpControllerDescriptor controllerDescriptor)
        {
            var lookup = base.GetActionMapping(controllerDescriptor);
            return lookup;
        }
    }
