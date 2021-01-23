    public class APIController : ApiController
    {
        [HttpGet]
        [Route("api/drones")]
        public HttpResponseMessage getDrones()
        {
            var drones = db.drones.ToList().Select(d => DroneDto.CreateFromEntity(d));
        
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, drones);
            return res;
        }
        [HttpGet]
        [Route("api/drones/{id}")]
        public HttpResponseMessage getDrones(int id)
        {
            var drone = db.drones.Where(d => d.iddrone == id)
                        .ToList().Select(d => DroneDto.CreateFromEntity(d));                                      
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, drone);
            return res;
        }
    }
