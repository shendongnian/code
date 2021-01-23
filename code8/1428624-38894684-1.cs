        public async Task StartAsync(IDialogContext context)
        {
            //await context.PostAsync("What rate would you like to check today?");
            context.Wait(BeginCurrencyDialog);
        }
        public async Task BeginCurrencyDialog(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            //this needs to be saved because neither Activity nor IDialogContext are serializable, but Hangfire needs it
            IMessageActivity activity = await argument;
            serviceUrl = activity.ServiceUrl;
            from = activity.From.Id;
            recipient = activity.Recipient.Id;
            conversation = activity.Conversation.Id;
            channelId = activity.ChannelId;
            activityId = activity.Id;
