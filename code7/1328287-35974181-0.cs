    public HttpResponseMessage Put(Friend friend)
    {
       if (!ModelState.IsValid)
       {
          return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
       }
       
       db.Entry(friend).State = EntityState.Modified;
       try
       {
          db.SaveChanges();
       }
       catch (DbUpdateConcurrencyException ex)
       {
          return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
       }
       return Request.CreateResponse(HttpStatusCode.OK);
    }
