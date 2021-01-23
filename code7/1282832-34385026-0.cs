    protected int? GetUserId()
    {
        return (User != null && User.Identity != null && User.Identity.IsAuthenticated) ? User.Identity.GetUserId() : null;
    }
    protected void GetUnreadInvitationCount()
    {
        int? userId = GetUserId();
        if (userId == null)
           throw new SecurityException("Not authenticated");
        var count = Db.Request.Where(r => r.ReceiverId == userId.value && r.DateLastRead == null).Count();
        if (count > 0) ViewBag.UnreadInvitations = count;
    }
