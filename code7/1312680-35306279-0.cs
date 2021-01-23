        .GroupBy(q => new {q.Top.Name, q.Top.TopicID })
		.Select(group => new
                           {
                               id = group.Key.TopicID,
                               name = group.Key.Name,
                               count = group.Count()
                           });
