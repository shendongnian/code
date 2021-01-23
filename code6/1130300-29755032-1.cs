    public ActionResult ViewProfile(int profileId)
    {
        var user = GetCurrentUser();//without looking at your code, I can't infer this piece.
        var profile = GetProfile(profileId);
        if(IsAuthorizedToEdit(user, profileId)
        {
            return View("edit", profile);
        }
        else
        {
            return View("view", profile);
        }
    }
