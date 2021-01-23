    [assembly: Xamarin.Forms.Dependency(typeof(ObjectFactory))]
    namespace YOURNAMESPACE
    {
    	public class ObjectFactory : IObjectFactory
    	{
    		public object CreateUninitialized(Type type)
    		{
    			return FormatterServices.GetUninitializedObject(type);
    		}
    	}
    }
