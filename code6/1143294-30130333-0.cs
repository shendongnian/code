    [RoutePrefix("api/workshop")]
    public class WorkshopController : ApiController {
        [HttpGet]
        [Route("Get")]
        public IList<Model> Get()
        {
            ...
        }
        [HttpGet]
        [Route("GetAllWorkshops")]
        public IList<Model> GetAllWorkshops()
        {
            ...
        }
    }
