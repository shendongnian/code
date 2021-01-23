        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        [Route("messages/{*wildcard}")]
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            var botId = Request.RequestUri.Segments.Last(); // Validate against your database / configuration
            try
            {
                if (activity.Type == ActivityTypes.Message)
                {
                    // https://docs.botframework.com/en-us/csharp/builder/sdkreference/stateapi.html
                    var stateClient = activity.GetStateClient();
                    BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);
                    userData.SetProperty("ApplicationAccountBotId", botId);
                    await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
                    await Conversation.SendAsync(activity, () => actionDialog);
                }
                else
                {
                    HandleSystemMessage(activity);
                }
            }
            catch (Exception exception)
            {
                await logger.ErrorAsync(exception);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
