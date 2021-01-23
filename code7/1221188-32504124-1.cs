    HashSet<Movie> movies = new HashSet<Movie>(new Movie.MovieEqualityComparer())
    {
    	new Movie { Name = "Star Trek" },
        new Movie { Name = "Star Wars" }
    };
    
    HashSet<User> users = new HashSet<User>(new User.UserEqualityComparer())
    {
    	new User { Name = "John" },
    	new User { Name = "Jack" }
    };
    
    // Now an user likes a movie:
    Movie movie = movies.Single(some => some.Name == "Star Trek");
    User user = users.Single(some => some.Name == "John");
    
    // You need to associate both sides of the whole M-N association:
    // A movie can be liked by many users and an user can like many movies...
    movie.UsersWhoLikeIt.Add(user);
    user.LikesMovies.Add(movie);
    
