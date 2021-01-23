    [LuisIntent("Greetings")]
    public async Task Greetings(IDialogContext context, LuisResult result)
    {
	var username = context.UserData.Get<string>("name");
	await context.PostAsync($"hi {username}");
        context.Wait(MessageReceived);
    }
