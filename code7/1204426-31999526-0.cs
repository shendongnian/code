    public Task<List<MovieDetail>> searchMovies(string movietitle)
    {
            List <MovieDetail> _myMovie = await GetMovieDetailsList(1);
            var list = await Task.Run(() => how do i query above here ???? >());
    
    
            List<MovieDetail> _mySearchDetail = _myMovie.Where(p => p.name == movietitle).ToList();
                return await tcs.Task;
    }
    _myMovie.Where(x => x.Name == "title"); 
