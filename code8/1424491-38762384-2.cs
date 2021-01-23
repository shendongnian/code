    public void AddRelationship(int movieId, int[] actorIds)
    {
        var movie = _context.Movies.FirstOrDefault(x => x.Id == movieId);
        if(movie == null)
        {
            // Now what?
            throw new Exception("Invalid movieId");
        }
        foreach(var actorId in actorIds)
        {
            var actor = new Actor
            {
                Id = actorId
            };
            _context.Actors.Attach(actor);
            movie.Actors.Add(actor); // EF will detect if it already exists or not.
        }
        _context.SaveChanges();
    }
