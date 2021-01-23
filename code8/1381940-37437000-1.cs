            [Route("DeleteThis/{id}")]
            [HttpDelete]
            public IHttpActionResult DeleteThis(int id)
            {
                return Ok();
            }
            [Route("NowDeleteThis/{name}")]
            [HttpDelete]
            public IHttpActionResult DeleteThis(string name)
            {
                return Ok();
            }
