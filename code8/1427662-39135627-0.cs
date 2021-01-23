    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
    {
        // Detect if this is a Message activity
        if (activity.Type == ActivityTypes.Message)
        {
            // Get any saved values
            StateClient sc = activity.GetStateClient();
            BotData userData = sc.BotState.GetPrivateConversationData(
                activity.ChannelId, activity.Conversation.Id, activity.From.Id);
            var boolProfileComplete = userData.GetProperty<bool>("ProfileComplete");
            if (!boolProfileComplete)
            {
                // Call our FormFlow by calling MakeRootDialog
                await Conversation.SendAsync(activity, MakeRootDialog);
            }
            else
            {
                // Get the saved profile values
                var FirstName = userData.GetProperty<string>("FirstName");
                var LastName = userData.GetProperty<string>("LastName");
                var Gender = userData.GetProperty<string>("Gender");
                // Tell the user their profile is complete
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("Your profile is complete.\n\n");
                sb.Append(String.Format("FirstName = {0}\n\n", FirstName));
                sb.Append(String.Format("LastName = {0}\n\n", LastName));
                sb.Append(String.Format("Gender = {0}", Gender));
                // Create final reply
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                Activity replyMessage = activity.CreateReply(sb.ToString());
                await connector.Conversations.ReplyToActivityAsync(replyMessage);
            }
        }
        else
        {
            // This was not a Message activity
            HandleSystemMessage(activity);
        }
        // Send response
        var response = Request.CreateResponse(HttpStatusCode.OK);
        return response;
    }
