    public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                // return our reply to the user
                return await Conversation.SendAsync(message, () => new EchoDialog());
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }
