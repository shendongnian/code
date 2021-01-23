	public class SerializerFilter : IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationContext context)
		{
            // TODO: Put some kind of if condition (possibly a 
            // global static variable) here to ensure this 
            // only runs when needed.
			Serializers.Test();
		}
	}
