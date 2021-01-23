    public override void OnSaveSession(
        IRequest httpReq, IAuthSession session, TimeSpan? expiresIn = null)
    {
        var customExpiry = ...
        base.OnSaveSession(httpReq, session, customExpiry);
    }
