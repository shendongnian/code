    [HttpPost]
        public IHttpActionResult PostClient(Client c)
        {
            db.Client.Add(c);
            db.SaveChanges();
            return Ok(c);
        }
