    var result = (from t in db.Topics
                  from s in t.SubTopics.DefaultIfEmpty()
                  select new
                  {
                      TopicId = t.TopicId,
                      SubTopicId = (int?)s.SubTopicId,
                      TopicName = t.Name,
                      SubTopicName = s.Name
                  })
                .ToListAsync();
