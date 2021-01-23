    public ActionResult GetUnreadInvitationCount()
    {
        string userId = User.Identity.GetUserId();
        var count = Db.Request.Where(r => r.ReceiverId == userId && r.DateLastRead == null).OrderByDescending(r => r.Id).Count();
        BaseViewModel model = new BaseViewModel {RequestCount = count};
        return View("UnreadInvitations", model);
    }
