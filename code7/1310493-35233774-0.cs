    using (var ctx = new TestContext())
    {
    	var isSubscribed = ctx.Topics.Any(topic => topic.ID == topicId 
    	                                   && topic.Users.Any(user => user.Id == userId));
    }
