    var strings = searchString.Split(' ');
    var finalPosts = new List<string>();
    if (!String.IsNullOrEmpty(searchString))
    {
        foreach (var splitString in strings)
        {
            finalPosts.Add(posts.Where(s => s.Title.Contains(splitString)));
        }     
    }
