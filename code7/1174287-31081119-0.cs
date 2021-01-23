    var result = db.Questions.GroupBy(x => new
    {
        x.Category,
        x.Topic
    }).Select(g => new
    {
        g.Key.Category,
        g.Key.Topic,
        Store1Rating = db.Questions.Where(x => x.Category == g.Key.Category && x.Topic == g.Key.Topic).Average(x => x.Store1Rating),
        Store2Rating = db.Questions.Where(x => x.Category == g.Key.Category && x.Topic == g.Key.Topic).Average(x => x.Store2Rating),
    });
