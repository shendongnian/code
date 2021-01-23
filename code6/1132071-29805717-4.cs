    using (var dbContext = new MyDbContext())
    {
        var movie = dbContext.Movies.SingleOrDefault(x => x.Name == name);
        movie.Categories.Add(dvd);
        dbContext.SaveChanges();
    }
