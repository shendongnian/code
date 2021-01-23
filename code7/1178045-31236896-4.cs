    public void SendMessage(string groupName, string message, string type = "msg")
    {
        var context = GlobalHost.ConnectionManager.GetHubContext<PushNotify>();
        context.Clients.Group(groupName).addNewMessageToPage(type, message);
    }
