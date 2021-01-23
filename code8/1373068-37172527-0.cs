    foreach(var topic in result)
    {
      Console.WriteLine("Topic:"+topic.Name);
      foreach(var subtopic in topic.SubTopics)
      {
        Console.WriteLine("  SubTopic:"+subtopic.Name");
      }
    }
