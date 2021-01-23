        TMDbLib.Objects.Movies.Movie movie = new MyMovie();
        movie = MovieProcesses.loadTMDbLib(justMovieName);
        MyMovie myMovie = movie as MyMovie;
        myMovie.Path = path;
        Cacher cache = new Cacher();
        cache.CacheVideo(myMovie);
