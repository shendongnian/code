    public class RawBodyBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if(typeof(string)!=bindingContext.ModelType)
                 return null;
            using (var s = new StreamReader(controllerContext.HttpContext.Request.InputStream))
            {
                s.BaseStream.Position = 0;
                return s.ReadToEnd();
            }      
        }
    }
