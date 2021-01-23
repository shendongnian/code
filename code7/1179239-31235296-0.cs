    [Authorize]
    public ActionResult Add (string id = "")
    {
        var model = _db.Users
                .OrderBy(r => r.UserName)
                .Where(r => r.Id == id).ToList()
                .Select(r => new FriendsList
                {
                    RequesterID = HttpContext.User.Identity.GetUserId().ToString(),
                    RequesteeID = id,
                    UserName = r.UserName,
                    Status = "NewRequest",
                    RequestDate = DateTime.Now,
                    AcknowledgeDate = DateTime.Now
                })
                .FirstOrDefault();
        if (model == null)
        {
            // handle not found
        }
        return View(model);
    }
