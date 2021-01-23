    using IModelBinder = System.Web.Mvc.IModelBinder;
    using ModelBindingContext = System.Web.Mvc.ModelBindingContext;
    public class CustomeModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //your code here
        }
    }
