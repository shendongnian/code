	// This topic already exists in the database.
	// No need to set value.
	var topic = new Topic{ Id = 6 };
	var message = new Message();
	message.Text = "Hello";	
	message.Topics.Add(topic); 
	dbContext.Messages.Add(message);
	
	// Set state of topic to Unchanged
	dbContext.Entry(topic).State = EntityState.Unchanged;
	dbContext.SaveChanges();
