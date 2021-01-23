            List<ChannelAccount> participants = new List<ChannelAccount>();
            participants.Add(new ChannelAccount("shansari@verizon.net", "Shahin Ansari"));
            IMessageActivity message = Activity.CreateMessageActivity();
            bool isGroup = false;
            ConversationParameters cpMessage = new ConversationParameters(message.Recipient, isGroup, participants, "Quarter End Discussion");
            var ConversationId = await connector.Conversations.CreateConversationAsync(cpMessage);  
            //message.From = botChannelAccount;
            message.From = new ChannelAccount();
            message.Conversation = new ConversationAccount();
            message.ChannelId = "email";
            
