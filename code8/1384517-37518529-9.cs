    [HttpPost]
        public IHttpActionResult PostClient(Client client)
        {
            db.Client.Add(client);
            db.SaveChanges();
            return Ok(client);
        }
