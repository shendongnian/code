    public IHttpActionResult PostCanonical(Canonical canonical)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        // Check for duplicate Canonical text for the same app name.
        if (db.IsDuplicateCanonical(canonical.AppName, canonical.Text))
        {
            // It's a duplicate.  Return an HTTP 409 Conflict error to let the client know.
            var original = db.CanonicalSentences.First(c => c.ID == canonical.ID);
            return new NegotiatedContentResult<T>(HttpStatusCode.Conflict, original, this);
        }
        db.CanonicalSentences.Add(canonical);
        db.SaveChanges();
        return CreatedAtRoute("DefaultApi", new { id = canonical.ID }, canonical);
    }
