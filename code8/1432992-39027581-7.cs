	public class EntityNameBusinessLayer
	{
		// private member, i left the naming the same but the usual convention for private members is camelcase and not pascal.
		private HttpRequest Request;
		// constructor
		public EntityNameBusinessLayer(HttpRequest request) {
			// check for null
			if(request == null)
				throw new ArgumentNullException("request");
			Request = request; // now the state of the instance is valid and it can be used by the caller
		}
		public string RetrieveUserBrowserDetails()
		{ /*your code*/ }
	}
