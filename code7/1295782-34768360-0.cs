    // PUT: api/Events/5
    [HttpPut]
    [ResponseType(typeof(void))]
    public IHttpActionResult PutEvent(int id, Event @event)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
    
        if (id != @event.Id)
        {
            return BadRequest();
        }
    
        db.Entry(@event).State = EntityState.Modified;
    
        try
        {
            db.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EventExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
    
        return StatusCode(HttpStatusCode.NoContent);
    }
