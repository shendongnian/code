    // GET api/Books/genres/horror
    [Route("genres/{genre}")]
    public IQueryable<string> GetBooksByGenre(string genre)
    {
        return null;
    }
