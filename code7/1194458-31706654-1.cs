    // PUT: api/Notes/5
    [ResponseType(typeof(void))]
    public IHttpActionResult PutNote(int id, Note note)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (id != note.NoteId)
            return BadRequest();
        
        //Not sure how you're setup, but have EF fetch the note you want
        //to modify from the DB. It is now aware of it and tracking changes.
        var model = _getNoteModelFromDbById(note.NoteId);
        
        //Now that you have the model from the DB you can map the properties 
        //of the incoming note to your model. Bellow is just a basic example.         
        //I recommend you look into a library called Automapper later on. 
         model.Title = note.Title;
         model.Description = note.Description;
         model.Status = note.Status;
        db.Entry(model).State = EntityState.Modified;
        try
        {
            db.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AttachmentExists(id))
                return NotFound();
            else
                throw;
        }
        return StatusCode(HttpStatusCode.NoContent);
    }
