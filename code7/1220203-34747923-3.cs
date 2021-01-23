        private IDroneDTORepository _repository = new DroneDTORepository(dbContext);
        [HttpGet]
        [Route("api/drones")]
        public HttpResponseMessage getDrones()
        {
            var drones = _repository.FindAll();
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, drones);
            return res;
        }
        [HttpGet]
        [Route("api/drones/{id}")]
        public HttpResponseMessage getDrones(int id)
        {
            var drone = _repository.Find(id);
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, drone);
            return res;
        }
