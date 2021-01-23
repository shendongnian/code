        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message"){
                Message ReplyMessage = message.CreateReplyMessage();
                ReplyMessage.ChannelData = getFBFunctionMenu();
                return ReplyMessage;
            }else{return HandleSystemMessage(message);}
        }
