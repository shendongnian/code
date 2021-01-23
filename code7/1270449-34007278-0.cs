    var userId = User.Identity.GetUserId();
    var client = db.Clients.SingleOrDefault(m => m.UserId == userId && m.ClientId == clientId);
    if (client == null)
    {
        return new HttpNotFoundResult();
    }
    // whatever
