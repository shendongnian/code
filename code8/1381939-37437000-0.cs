            [Route("DeleteThis/{id}/")]
            public IHttpActionResult DeleteThis(int id)
            {
                return Ok();
            }
            [Route("NowDeleteThis/{name}/")]
            public IHttpActionResult DeleteThis(string name)
            {
                return Ok();
            }
