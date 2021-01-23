    var users = Request.Form.GetValues("users[]") == null ? null : Request.Form.GetValues("users[]").ToArray();
    if(users != null)
    {
         List<QuickSearchView> qsvs = db.QuickSeachViews.ToList();
         var submississions = qsvs.Where(x => users.Any(x.UserId));
    }
    else
    {
          //something when users is null
    }
