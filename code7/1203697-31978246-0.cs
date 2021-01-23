    public string[] GetAuthorsById(int id)
    {
        List<string> authors = new List<string>();
        foreach (var author in context.Authors
                                      .Where(a => a.Id == id)
                                      .ToList())
        {
            authors.Add(author.Name);
        }
        return authors.ToArray();
    }
