    [HttpPost, ValidateAntiForgeryToken]
    public ActionResult Default(string settings)
    {
        FacebookFeedSettings facebookSettings = FacebookFeedSettings.FromEncryptedString(settings);
        // do something with the settings
        // build the model
        return PartialView(model);
    }
