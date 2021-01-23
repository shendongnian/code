      db.Kweets.Select(c => new KweetList()
        {
             Content = c.Content,
             AuthorName = c.Author.Username,
             TimePlaced = c.TimePlaced
        }).ToList()
