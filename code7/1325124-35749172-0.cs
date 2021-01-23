    public async Task SendMessageAsync(IUser sender, IChatMessage message, string channelID, CancellationToken token)
        {
            await loginIfRequired(sender, token);
            var jsonMessage = JsonConvert.SerializeObject(message);
            var recipientID = await getQuickbloxUserId(message.RecipientID, token);
            var extraParams = "<extraParams> " +
                                "<save_to_history>1</save_to_history> " +
                              "</extraParams>";
            _quickblox.ChatXmppClient.SendMessage(recipientID, jsonMessage, extraParams, channelID);
        }
