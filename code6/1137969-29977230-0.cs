    [HttpPost]
    public ActionResult Login(LoginModel model, string returnUrl)
    {
      // validate user here
      if (validUser)
      {
        var loseATonEvent = db.Events.Max(e => e.EventId);
        var currentUser = User.Identity.Name;
        Session["isSignedUp"] = ConfirmIsSignedUp(loseATonEvent, currentUser);
        Session["canSignUp"] = ConfirmCanSignUp(loseATonEvent);
        Session["canWeighIn"] = ConfirmCanWeighIn(loseATonEvent);
        // return user to destination URL
        return Redirect(returnUrl);
      }
    }
