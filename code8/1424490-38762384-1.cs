    public void ReplaceRelationship(int movieId, int[] actorIds)
    {
        var movie = _context.Movies.FirstOrDefault(x => x.Id = movieId);
        var existingActorIds = movie.Actors.Select(x => x.Id).ToList();
        // Add new values.
        foreach (var actorId in actorIds.Where(x => !existingActorIds .Contains(x.Id)))
        {
            var newActor = _context.Actors.Find(actorId );
            movie.Actors.Add(newActor );
        }
        var idsToRemove =
            existingValueIds.Where(x => !actorIds.Contains(x));
        // Remove the old ones
        foreach (var actorId in idsToRemove)
        {
            var actorEntity = movie.Actors.FirstOrDefault(x => x.Id== actorId );
            movie.Actors.Remove(actorEntity);
        }
        _context.SaveChanges();
    }
