        [HttpGet]
        [Route("enterprise/")]
        [ResponseType(typeof(EnterpriseViewModel))]
        public IHttpActionResult Get()
        {
            ...
        }
