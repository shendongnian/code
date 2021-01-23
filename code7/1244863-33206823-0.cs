    public class CustomModelBinderBinder : DefaultModelBinder
    {
    	private readonly Dictionary<string, object> _extraProperties;
    	
       public CustomModelBinderBinder(dynamic extraProperties)
       {
       		var props = typeof(extraProperties).GetProperties(BindingFlags.Public).ToList();
       		_extraProperties = props.ToDictionary(p => p.Name, p => p.GetValue(extraProperties));
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
