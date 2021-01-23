    private async Task _reset(Activity activity)
        {
            await activity.GetStateClient().BotState
                .DeleteStateForUserWithHttpMessagesAsync(activity.ChannelId, activity.From.Id);
            var client = new ConnectorClient(new Uri(activity.ServiceUrl));
            var clearMsg = activity.CreateReply();
            clearMsg.Text = $"Reseting everything for conversation: {activity.Conversation.Id}";
            await client.Conversations.SendToConversationAsync(clearMsg);
        }
