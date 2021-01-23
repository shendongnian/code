    public class CustomModelBinderBinder : DefaultModelBinder
    {
    	private readonly Dictionary<string, object> _extraProperties;
    	
       public CustomModelBinderBinder(Dictionary<string, object> extraProperties)
       {
            _extraProperties = extraProperties;
       }
    
    	public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
       	{
        	var model = bindingContext.Model;
        	var modelType = model.GetType();
    		var modelProperties = modelType.GetProperties(BindingFlags.Public);
    		
        	foreach (var property in _extraProperties)
           	{
               var matchingProperty = modelType.GetProperties().FirstOrDefault(p => p.Name == property.Key);
               
    			if (matchingProperty != null)
               	{
    				try
    				{	        
    	            	matchingProperty.SetValue(model, property.Value);
    				}
    				catch (Exception ex)
    				{
    					// what happens when we fail to set this value?
    					// possibly due to type mismatch, or readonly property
    					throw;
    				}
               	}
           	}
       	}
    }
