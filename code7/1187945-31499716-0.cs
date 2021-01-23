    var accessedTopicsByCode = topicsB.ToDictionary(x => x.TopicCode);
    foreach (var t in topicsA)
    {
        if (accessedTopicsByCode.ContainsKey(t.TopicCode))
        {
            t.TopicAccessed = true;
        }
    }
