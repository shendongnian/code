    public class CastRoutingConvention : EntitySetRoutingConvention
    {
    	public override string SelectAction(ODataPath odataPath, HttpControllerContext controllerContext, ILookup<string, HttpActionDescriptor> actionMap)
    	{
    		if (odataPath.PathTemplate == "~/entityset/cast")
    		{
    			HttpMethod httpMethod = controllerContext.Request.Method;
    
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
