    public class DynamicBinder : IModelBinder
    	{
    		public object BindModel( ControllerContext controllerContext, ModelBindingContext bindingContext )
    		{
    			using( var streamReader = new StreamReader( controllerContext.HttpContext.Request.InputStream ) )
    			{
    				return JsonConvert.DeserializeObject< dynamic >( streamReader.ReadToEnd() );
    			}
    		}
    	}
