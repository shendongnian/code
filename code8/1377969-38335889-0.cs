    public class MessageModelBinderProvider : IModelBinderProvider 
    {
    	public IModelBinder GetBinder(ModelBinderProviderContext context)
    	{
    		if (context == null)
    		{
    			throw new ArgumentNullException(nameof(context));
    		}
    
    		if (context.Metadata.ModelType != typeof(ICommand))
    		{
    			return null;
    		}
    
    		var binders = new Dictionary<string, IModelBinder>();
    		foreach (var type in typeof(MessageModelBinderProvider).GetTypeInfo().Assembly.GetTypes())
    		{
    			var typeInfo = type.GetTypeInfo();
    			if (typeInfo.IsAbstract || typeInfo.IsNested)
    			{
    				continue;
    			}
    
    			if (!(typeInfo.IsClass && typeInfo.IsPublic))
    			{
    				continue;
    			}
    
    			if (!typeof(ICommand).IsAssignableFrom(type))
    			{
    				continue;
    			}
    
    			var metadata = context.MetadataProvider.GetMetadataForType(type);
    			var binder = context.CreateBinder(metadata);
    			binders.Add(type.FullName, binder);
    		}
    
    		return new MessageModelBinder(context.MetadataProvider, binders);
    	}
    }
