    var result = db.Questions.GroupBy(x => new
    //grouping data by category and topic, rows which have same category and topic will be in a group
    {
        x.Category,
        x.Topic
    }).Select(g => new
    //now selecting category and topic for each group and the data we want
    {
        g.Key.Category,
        g.Key.Topic,
        //calculate Store1Rating average of all rows which has same category and topic as this group
        Store1Rating = db.Questions.Where(x => x.Category == g.Key.Category && x.Topic == g.Key.Topic).Average(x => x.Store1Rating),
        //calculate Store2Rating average of all rows which has same category and topic as this group
        Store2Rating = db.Questions.Where(x => x.Category == g.Key.Category && x.Topic == g.Key.Topic).Average(x => x.Store2Rating),
    });
