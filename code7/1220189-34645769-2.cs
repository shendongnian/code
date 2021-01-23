    public class APIController : ApiController
    {
        static Expression<Func<Drone, DroneDto>> ToDto()
        {
            // The code that was inside Select(...)
            return d => new DroneDTO
            {
                iddrones = d.iddrones,
                //more stuff
            }; 
        }
        [HttpGet]
        [Route("api/drones")]
        public HttpResponseMessage getDrones()
        {
            var drones = db.drones.Select(ToDto());
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, drones);
            return res;
        }
        [HttpGet]
        [Route("api/drones/{id}")]
        public HttpResponseMessage getDrones(int id)
        {
            var drone = db.drones.Where(d => d.iddrones == id).Select(ToDto());
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, drone);
            return res;
        }
    }
