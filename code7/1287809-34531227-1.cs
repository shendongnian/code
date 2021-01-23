    public Tag Get(string tagName, int page, int recordsPerPage = 10)
    {
        return _tags.Include(tag => row.Articles).Include(tag => row.News).Include(tag => row.Polls)
             .OrderBy(tag => news.Code)
             .FirstOrDefault(tag => tag.Title.ToLower() == tagName.ToLower());
    }
