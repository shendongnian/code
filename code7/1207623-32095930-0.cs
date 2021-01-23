    public async Task<List<MovieDetail>> GetMovieDetailsList(int movieId)
    {
        string jsonresult = await WCFRESTServiceCall("GET", "movie_details");
        var list = jsonresult.Deserialize<List<MovieDetail>>();
        return list;
    }
