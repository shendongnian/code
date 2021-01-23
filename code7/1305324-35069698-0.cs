    [HttpPost]
        [Route("api/delete")]
        public IHttpActionResult delete([FromBody]Product p)
            {
            try {
    
                _db.deleteProduct(p.ID);
    
                return Ok(1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
