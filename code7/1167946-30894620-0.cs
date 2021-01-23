    context.Movies.AddOrUpdate(
        i => i.Title,
            new MvcMovie.Models.Movie
              //^^^^^^^^^^^^^^^^^^^^^ Note the full namespace here
            {
                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1989-1-11"),
                Genre = "Romantic Comedy",
                Price = 7.99M
            },
