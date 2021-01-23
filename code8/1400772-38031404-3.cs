    [RoutePrefix("api/Locations")]
    public class LocationsController : ApiController
    {
        IlocationsRepository locationsRepo;
        public LocationsController(IlocationsRepository _repo)
        {
            if (_repo == null) { throw new ArgumentNullException("_repo"); }
            this.locationsRepo = _repo;
        }
        //GET api/locations
        [HttpGet]
        [Route(""}]
        public IEnumerable<Location> GetAll()
        {
            return locationsRepo.GetAll();
        }
    }
