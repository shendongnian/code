	public override object BindModel(Controller context, ModelBindingContext bindingContext)
	{
		var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
		object returnVal = base.BindModel(controllerContext, bindingContext);
		/* check returnVal and then additional custom logic here */.
		
		return returnVal;
	}
