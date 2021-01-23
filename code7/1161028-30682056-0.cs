        using (var db = new MovieDbModel("Server=localhost;Database=test;Trusted_Connection=True;"))
        {
            var movie = new Movie()
            {
                Title = "Test",
                Year = 1990
            };
            var actor = new Actor
            {
                FirstName = "Al",
                LastName = "Pacino"
            };
            db.Actor.Add(actor);
            actor.Movie.Add(movie);
             
            db.SaveChanges();
        }
