    private async Task HandleSystemMessage(Activity message)
    {
    	if (message.Type == ActivityTypes.DeleteUserData)
    	{
    		// Implement user deletion here
    		// If we handle user deletion, return a real message
    	}
    	else if (message.Type == ActivityTypes.ConversationUpdate)
    	{
    		if (message.MembersAdded.Any(o => o.Id == message.Recipient.Id))
    		{
    			var RootDialog_Welcome_Message = "welcome! i'm rainmaker";
    			var reply = message.CreateReply(RootDialog_Welcome_Message);
    
    			ConnectorClient connector = new ConnectorClient(new Uri(message.ServiceUrl));
    
    			await connector.Conversations.ReplyToActivityAsync(reply);
    		}
    	}
    	else if (message.Type == ActivityTypes.ContactRelationUpdate)
    	{
    		// Handle add/remove from contact lists
    		// Activity.From + Activity.Action represent what happened
    	}
    	else if (message.Type == ActivityTypes.Typing)
    	{
    		// Handle knowing tha the user is typing
    	}
    	else if (message.Type == ActivityTypes.Ping)
    	{
    	}
    }
