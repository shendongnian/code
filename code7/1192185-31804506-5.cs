	public class ValuesController : ApiController
	{
		// GET api/values/5
		[Route( "api/values/{id}" )]
		public string Get([CustomParameterBinding] string id )
		{
			return id;
		}		
	}
