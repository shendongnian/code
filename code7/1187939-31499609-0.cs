    // We iterate though the items of topicsA list.
    foreach(var topicA in topicsA)
    {
        // If topicsB list contains any item with the same TopicCode like 
        // the current's item TopicCode, update the TopicAccessed.
        if(topicsB.Any(x=>x.TopicCode == topicaA.TopicCode))
        {
            topicA.TopicAccessed = true;
        }
    }
