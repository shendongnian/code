    var query=from t in db.Topics
              join st in db.SubTopics on t.TopicId equals st.TopicId int g
              from s in g.DefaultIfEmtpy
              select new {
                           TopicId = t.TopicId,
                           SubTopicId = s!=null?s.SubTopicId:null,
                           TopicName = t.Name,
                           SubTopicName =  s!=null?s.Name:null
                         }; 
            
