	// Get topic from source
	var topic = dbContext.Topics.FirstOrDefault(m => m.Id == 6);
	var message = new Message();
	message.Text = "Hello";
	message.Topics.Add(topic); 
	dbContext.Messages.Add(message);
	dbContext.SaveChanges();
