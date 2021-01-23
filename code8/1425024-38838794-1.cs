            message.Text = "Hey, what's up everyone?";
            message.Locale = "en-Us";
            connector.Conversations.SendToConversation((Activity)message);
            //await connector.Conversations.SendToConversation((Activity)message);
            var replyMessage = activity.CreateReply("Yo, I heard you Sean.", "en");
            await connector.Conversations.ReplyToActivityAsync(replyMessage);  
