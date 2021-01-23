    [Authorize, ValidateAntiForgeryToken]
    [HttpPost]
    public ActionResult NukeMyBankAccount(int accountId)
    {
        var account = db.GetAccount(accountId);
        // validate
        if (CurrentUser.Id != account.Owner.Id)
        {
            return RedirectToAction("Unauthorized");
        }
        else
        {
            db.NukeAccount(accountId, areYouSure: true);
        }
        ...
    }
