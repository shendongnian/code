    public class CastRoutingConvention : EntitySetRoutingConvention
    {
    	public override string SelectAction(ODataPath odataPath, HttpControllerContext controllerContext, ILookup<string, HttpActionDescriptor> actionMap)
    	{
    		if (odataPath.PathTemplate == "~/entityset/cast")
    		{
    			HttpMethod httpMethod = controllerContext.Request.Method;
                var collectionType = (IEdmCollectionType)odataPath.EdmType;
                var entityType = (IEdmEntityType)collectionType.ElementType.Definition;
        
                var type = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => !a.IsDynamic)
                    .SelectMany(a => a.DefinedTypes)
                    .FirstOrDefault(t => t.FullName == entityType.FullTypeName());
        
                controllerContext.RouteData.Values["type"] = type;
    
    			if (httpMethod == HttpMethod.Get)
    				return "GetFrom";
    			else if (httpMethod == HttpMethod.Post)
    				return "PostFrom";
    			else
    				return base.SelectAction(odataPath, controllerContext, actionMap);
    		}
    		else
    			return base.SelectAction(odataPath, controllerContext, actionMap);
    	}
    }
