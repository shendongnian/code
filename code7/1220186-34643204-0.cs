        public class DroneDTO
        {
            public int Id { get; set; }
            public static IEnumerable<DroneDTO> CreateFromQuery(IQueryable<Drone> query)
            {
                return query.Select(r=> new DroneDTO
                {
                    Id = r.Id
                });
            }
        }
        public class APIController : ApiController
        {
            [HttpGet]
            [Route("api/drones")]
            public HttpResponseMessage getDrones()
            {
                var drones = DroneDTO.CreateFromQuery(db.drones);
                HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, drones);
                return res;
            }
            [HttpGet]
            [Route("api/drones/{id}")]
            public HttpResponseMessage getDrones(int id)
            {
                var drone = DroneDTO.CreateFromQuery(db.drones.Where(d => d.iddrone == id));
                HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, drone);
                return res;
            }
        }
