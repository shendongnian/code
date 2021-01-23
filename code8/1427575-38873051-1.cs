    using (var context = new MyDbContext(...))
    {
        IQueryable<Article> articlesOfTopicsWithTopicName = context.Topics
            .Where(topc=> topc.Name == myTopicName)
            .SelectMany(topic => topic.Articles);
