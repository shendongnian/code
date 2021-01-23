    using System;
    using System.Web.Http.Controllers;
    using System.Web.Http.ModelBinding;
    
    namespace Example
    {
    	public class RouteDataModelBinder : IModelBinder
    	{
    		public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
    		{
    			object model;
    
    			if (!actionContext.RequestContext.RouteData.Values.TryGetValue(bindingContext.ModelName, out model))
    			{
    				bindingContext.ModelState.AddModelError(bindingContext.ModelName, $"No route data named '{bindingContext.ModelName}'.");
    				return false;
    			}
    			else if (!bindingContext.ModelType.IsAssignableFrom(model.GetType()))
    			{
    				try
    				{
    					model = Convert.ChangeType(model, bindingContext.ModelType);
    				}
    				catch
    				{
    					bindingContext.ModelState.AddModelError(bindingContext.ModelName, $"Route data cannot be converted to type '{bindingContext.ModelType.FullName}'.");
    					return false;
    				}
    			}
    
    			bindingContext.Model = model;
    			return true;
    		}
    	}
    
    	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
    	public class RouteDataAttribute : ModelBinderAttribute
    	{
    		public RouteDataAttribute()
    		{
    			this.BinderType = typeof(RouteDataModelBinder);
    		}
    	}
    }
