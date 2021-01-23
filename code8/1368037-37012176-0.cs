    using (var context = new IW5Context())
    {
        context.Films.Attach(ratedFilm);
        context.Ratings.Add(newRating);
        context.SaveChanges();
    }
