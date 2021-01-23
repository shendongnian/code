    var movies = new List<Movie>
            {
                new Movie {Title = "Pineapple Express", ReleaseDate = DateTime.Parse("2008-08-06"), Rating = Rating.R,Genre.Add(Genres.Action.ToString())}//You can use AddRange to add more than one genre
            };
    
            movies.ForEach(m => context.Movies.Add(m));
            context.SaveChanges();
