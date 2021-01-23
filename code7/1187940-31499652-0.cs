    var hash = new Dictionary<string,bool>();
    
    foreach(var topicB in topicsB)
    {
        hash[topicB.TopicCode] = true;
    }
    
    foreach(var topicA in topicsA)
    {
        topicA.TopicAccessed = hash[topicA.TopicCode]
    }
