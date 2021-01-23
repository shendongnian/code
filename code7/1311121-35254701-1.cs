    var user = new User { Id = userId };
    var topic = new Topic { Id = topicId };
    context.Users.Attach(user);
    context.Topics.Attach(topic);
    context.Entry(topic).Collection(t => t.Users).Load();  // explicitly load Users ...
    topic.Users.Remove(user);
