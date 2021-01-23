        [HttpGet, Route("myResource")]
        public virtual IHttpActionResult GetThings()
        {
            var query = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            var queryParam = query["$myParam"];
            return Ok();
        }
