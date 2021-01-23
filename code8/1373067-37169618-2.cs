    var query=from t in db.Topics
              join st in db.SubTopics on t.TopicId equals st.TopicId into g
              from s in g.DefaultIfEmtpy
              select new {
                           TopicId = t.TopicId,
                           SubTopicId = s.SubTopicId,
                           TopicName = t.Name,
                           SubTopicName =  s.Name
                         }; 
            
