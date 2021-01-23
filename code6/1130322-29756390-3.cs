    public async Task<ActionResult> Add(Movie model)
    {
        if(ModelState.IsValid)
        {
            using (var reader = new System.IO.BinaryReader(model.Content.InputStream))
            {
                movie.Image = reader.ReadBytes(model.Content.ContentLength);
            }
               //Plug in your db context
               db.Movies.Add(movie);
               await db.SaveChangesAsync();
               return redirectToAction("Index");
        }
    
        Return View();
    }
