        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            try
            {
                if (activity.Type == ActivityTypes.Message)
                {
                    //if the user types certain messages, quit all dialogs and start over
                    string msg = activity.Text.ToLower().Trim();
                    if (msg == "start over" || msg == "exit" || msg == "quit" || msg == "done" || msg =="start again" || msg == "restart" || msg == "leave" || msg == "reset")
                    {
                        //This is where the conversation gets reset!
                        activity.GetStateClient().BotState.DeleteStateForUser(activity.ChannelId, activity.From.Id);
                    }
                    
                    //and even if we reset everything, show the welcome message again
                    BotUtils.SendTyping(activity); //send "typing" indicator upon each message received
                    await Conversation.SendAsync(activity, () => new RootDialog());
                }
                else
                {
                    HandleSystemMessage(activity);
                }
            }
