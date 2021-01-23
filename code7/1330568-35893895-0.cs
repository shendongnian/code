    public class CarsController : ApiController
    {
        [HttpGet]
        [Route("api/cars")]
        public IEnumerable<Car> Get() { ... }
        [HttpGet]
        [Route("api/cars/{id}")]
        public HttpResponseMessage Get(int id)  { ... }
        [HttpPost]
        [Route("api/cars")]
        public HttpResponseMessage Post(Car car)  { ... }
        [HttpPut]
        [Route("api/cars/{id}")]
        public HttpResponseMessage Put(int id, Car car)  { ... }
        [HttpDelete]
        [Route("api/cars/{id}")]
        public HttpResponseMessage Delete(int id)  { ... }
    }
