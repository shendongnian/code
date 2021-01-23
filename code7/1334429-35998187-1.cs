    [HttpPut]
    public async Task<IHttpActionResult> Put(int id, ModelDTO modelDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        // Get the model that you are trying to update from the DB
        // using the id:
        var model = db.Models.Find(id);
        if (model == null)
        {
            // the id that was provided as parameter doesn't exist
            // we don't need to go any further, just let the client know
            // by returning 404
            return this.NotFound();
        }
        // set the properties that you want to update (only Name in your case)
        // of course when you have more complex models you might consider using
        // AutoMapper to take care of this part, but for the purposes of this
        // demonstration you don't need it:
        model.Name = modelDTO.Name; 
        // Now save the changes back to your database
        await db.SaveChangesAsync();
        return StatusCode(HttpStatusCode.NoContent);
    }
