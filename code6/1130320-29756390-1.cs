    public async Task<ActionResult> Add(Movie model)
    {
        if(ModelState.IsValid)
        {
            using (var reader = new System.IO.BinaryReader(model.Content))
            {
                movie.Image = reader.ReadBytes(model.Content.InputStream);
            }
               //Plug in your db context
               db.Movies.Add(movie);
               await db.SaveChangesAsync();
               return redirectToAction("Index");
        }
    
        Return View();
    }
