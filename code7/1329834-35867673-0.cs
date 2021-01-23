    private async Task<List<RemotePresentityNotification>> GetNotifications(UserEndpoint endpoint, string useridSIP)
    {
        return Task.Factory.FromAsync(
            _userEndpoint.PresenceServices.BeginPresenceQuery,
            _userEndpoint.PresenceServices.EndPresenceQuery,
            new[] { useridSIP },
            new[] { "state" });
    }
