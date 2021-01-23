    List<int> authorId = (List<int>)db.Books
        .Where(x => x.datePublished >= InitialDate)
        .Where(x => x.datePublished <= FinalDate)
        .GroupBy(x => x.authorId)
        .Select(g => new { authorId = g.Key, count = g.Count() })
        .Where(g => g.Count >= 3)
        .Select(g.authorId);
I make every single step so you can see it better, fell free to optimized as needed. The key thing here is the new { authorId = g.Key, count = g.Count().
