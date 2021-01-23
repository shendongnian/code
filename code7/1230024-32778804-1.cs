    [Route("api/games/{pageNumber}/{pageSize}")]
    public GamesHolder GetGames(int pageNumber, int pageSize)
    {            
        List<Game> games = db.Games.ToList();
        return new GamesHolder()
        {
           TotalCount = games.Count,
           PagedGames = new PagedList<Game>(games, pageNumber, pageSize)
        }
    }
