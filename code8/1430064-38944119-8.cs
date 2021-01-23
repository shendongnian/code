    internal class SiteModelBinder : System.Web.Mvc.IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            // use Json.NET to deserialize the incoming Position
            controllerContext.HttpContext.Request.InputStream.Position = 0; // see: https://stackoverflow.com/a/3468653/331281
            Stream stream = controllerContext.RequestContext.HttpContext.Request.InputStream;
            var readStream = new StreamReader(stream, Encoding.UTF8);
            string json = readStream.ReadToEnd();
            return JsonConvert.DeserializeObject<Site>(json, new JsonBuildBlockConverter());
        }
    }
