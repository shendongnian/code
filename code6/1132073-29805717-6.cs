    using (var dbContext = new MyDbContext())
    {
        var movie = dbContext.Movies.SingleOrDefault(x => x.Name == name);
        movie.Categories.Add(new Category() { Name = "Romance"});
        dbContext.SaveChanges();
    }
