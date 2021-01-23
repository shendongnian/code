    public class SomeController : ApiController
    {
        [Route("Street/{ZoneID}/{StreetID}/")]
        public HttpResponseMessage GetStreet(int ZoneID, int StreetID, [FromUri] RealEstateFilter Filter)
        {
            return null;
        }
