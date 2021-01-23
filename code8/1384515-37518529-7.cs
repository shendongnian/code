    [HttpPost]
        public IHttpActionResult PostClient(Client client)
        {
            db.Client.Add(c);
            db.SaveChanges();
            return Ok(c);
        }
