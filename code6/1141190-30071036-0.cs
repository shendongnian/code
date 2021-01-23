    [HttpPost]
    public ActionResult CreateSomething([ModelBinder(typeof(MyCustomModelBinder))] Something something) 
    {
    }
    public class MyCustomModelBinder : DefaultModelBinder
    {
    	public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    	{
    		// Do something
    		return base.BindModel(controllerContext, bindingContext);
    	}
    }
