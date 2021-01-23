    // POST: api/Reviews
    [ResponseType(typeof(Review))]
    public async Task<IHttpActionResult> PostReview(Review review) {
       
        if (review == null) ModelState.AddModelError("", "invalid data");
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        
        db.Reviews.Add(review);
        try {
            await db.SaveChangesAsync();
        } catch (DbUpdateException) {
            if (ReviewExists(review.ReviewID)) {
                return Conflict();
            } else {
                throw;
            }
        }
        return CreatedAtRoute("DefaultApi", new { id = review.ReviewID }, review);
    }
