     public void AddWeights(IEnumerable<Topic> topics)
     {
         const double TopicWeight = 0.8;
    
         if (Topics == null || !Topics.Any() || !topics.Any())
            return;
    
         foreach(var topic in topics)         
            if (Topics.Contains(topic, StringComparer.CurrentCultureIgnoreCase))
                Weight += TopicWeight;
     }
