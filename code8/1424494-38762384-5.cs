    public void ReplaceRelationship(int movieId, int[] actorIds)
    {
        var movie = _context.Movies.FirstOrDefault(x => x.Id = movieId);
        // You might possible need to to like this:
        //_context.Movies.Include(x => x.Actors).FirstOrDefault(x => x.Id = movieId);
        if(movie == null)
        {
            // Now what?
            throw new Exception("Invalid movieId");
        }
        // Get a list of the already existing actors, so we know which to remove.
        var existingActorIds = movie.Actors.Select(x => x.Id).ToList();
        // Add new actors.
        foreach (var actorId in actorIds.Where(x => !existingActorIds .Contains(x.Id)))
        {
            var newActor = _context.Actors.Find(actorId );
 
           // You might be able to use this instead.
           // var newActor = new Actor { Id = actorId };
           // _context.Actors.Attach(newActor);
            movie.Actors.Add(newActor );
        }
        var idsToRemove =
            existingActorIds.Where(x => !actorIds.Contains(x));
        // Remove the old ones
        foreach (var actorId in idsToRemove)
        {
            var actorEntity = movie.Actors.FirstOrDefault(x => x.Id== actorId );
            // Again, you should be able to use Attach like above.
            movie.Actors.Remove(actorEntity);
        }
        _context.SaveChanges();
    }
