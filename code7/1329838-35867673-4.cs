    private async Task<List<RemotePresentityNotification>> GetNotifications(UserEndpoint endpoint, string useridSIP)
    {
        var task = Task.Factory.FromAsync(
            _userEndpoint.PresenceServices.BeginPresenceQuery,
            _userEndpoint.PresenceServices.EndPresenceQuery,
            new[] { useridSIP },
            new[] { "state" });
       var results = await task;
       return results.ToList();
    }
