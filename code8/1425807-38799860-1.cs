    [RoutePrefix("api/masstimes")]
    public class MassTimesController : ApiController
    {
    	[HttpGet]
    	[Route("{lat}/{lon}")]
    	public ICollection<string> SomeMethod(double lat, double lon, [FromUri] TimeSpan time)
    	{
    		string[] mylist = { lat.ToString(), lon.ToString(), time.ToString() };
    		return new List<string>(myList);
    	}
    }
