    [RoutePrefix("api/prospect")]
    public class ProspectController: ApiController
    {
		[Route("{id}")]
		public ProspectDetail Get(int id)
		{
			...
			return prospect;
		}
    }
