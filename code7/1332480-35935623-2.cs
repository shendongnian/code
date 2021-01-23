    public void Like(Guid albumId, Guid managerId,string buttonID) //include parameter to accept button Id
    {
        IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
        var LikeCounter = SaveLike(albumId, managerId);
        Clients.All.updateLikeCount(LikeCounter,buttonID); //pass back the button id as well.
    }
