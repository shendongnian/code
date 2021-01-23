    using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
    {
        var client = scope.Resolve<IConnectorClient>();
    
        var data = await client.Bots.GetUserDataAsync(botId, userId);
        
        data.SetProperty("key", "value");
        
        await client.Bots.SetUserDataAsync(botId, userId, data);
    }
