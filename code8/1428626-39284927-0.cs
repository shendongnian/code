    case ActivityTypes.Message:
						
        StateClient stateClient = activity.GetStateClient();		
        BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);
	    userData.SetProperty<string>("name", activity.From.Name);
	    //other properties you want to set.
	    await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
