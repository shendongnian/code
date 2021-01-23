    DbSet<TopicFromDatabase> table;
    var topics = table.GroupBy(t => new 
                      {
                          t.TopicId,
                          t.TopicName,
                          t.LanguageId,
                          t.ApplicationId
                      })
                      .Select(g => new Topic
                      {
                          TopicId = g.Key.TopicId,
                          TopicName = g.Key.TopicName,
                          LanguageId = g.Key.LanguageId,
                          ApplicationId = g.Key.ApplicationId,
                          Articles = g.Select(a => new Article
                                      {
                                          ArticleId = a.ArticleId,
                                          Headline = a. Headline,
                                          Content = a. Content,
                                          IsSticky = a. IsSticky
                                      })
                      }
