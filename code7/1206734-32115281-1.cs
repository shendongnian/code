       public IHttpActionResult Get(int id)
            {
                var product = db.TESTS.FirstOrDefault((p) => p.ID == id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);         
            }
