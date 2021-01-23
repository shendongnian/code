    var hubConnection = new HubConnection("**YOUR URL**);
    await hubConnection.Start();
    IHubProxy proxy = hubConnection.CreateHubProxy("ReminderHub");
    
    // QUERY THE DATABASE Check if there's any user to notify
    for(var username in UsersToNotify){
    	proxy.Invoke("Notify", username);
    
    }
