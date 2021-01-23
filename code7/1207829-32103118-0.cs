    public class MyComplexBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // check type of the object you are going to bind with 
            // bindingContext.ModelType
            // if you could generate this kind of object use
            // controllerContext.HttpContext.Request.Form
            // or anything else and return generated object
            return GenerateMyComplexObject(controllerContext); 
        }
    }
