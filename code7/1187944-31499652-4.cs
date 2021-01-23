    var hash = new HashSet<string>();
       
    foreach(var topicB in topicsB)
    {
        hash.Add(topicB.TopicCode);
    }
        
    foreach(var topicA in topicsA)
    {
            topicA.TopicAccessed = hash.Contains(topicA.TopicCode);
    }
