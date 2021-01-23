        public class APIController : ApiController
        {
            private readonly IDroneService _droneService;
            public APIController(IDroneService droneService)
            {
                _droneService = droneService;
            }
            [HttpGet]
            [Route("api/drones")]
            public HttpResponseMessage GetDrones()
            {
                var drones = _droneService
                    .GetDrones()
                    .Select(DroneDTOFactory.Build);
                return Request.CreateResponse(HttpStatusCode.OK, drones);
            }
            [HttpGet]
            [Route("api/drones/{id}")]
            public HttpResponseMessage GetDrones(int id)
            {
                // I am assuming you meant to get a single drone here
                var drone = DroneDTOFactory.Build(_droneService.GetDrone(id));
                return Request.CreateResponse(HttpStatusCode.OK, drone);
            }
        }
        public static class DroneDTOFactory
        {
            public static DroneDTO Build(Drone d)
            {
                if (d == null)
                    return null;
                return new DroneDTO
                {
                    iddrones = d.iddrones,
                    //more stuff
                };
            }
        }
