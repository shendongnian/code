    async Task<bool> SetupUserAccessControlAsync(int objectId)
    {
        var tasks = new List<Task<bool>>();
        tasks.Add(AddToUserRoleBridgeAsync("Everyone", objectId));
        tasks.Add(AddToUserRoleBridgeAsync("Default", objectId));
        
        return (await Task.WhenAll(tasks)).All(_ => _);
    }
