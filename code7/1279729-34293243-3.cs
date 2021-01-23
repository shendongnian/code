    public async Task<IActionResult> Edit(int accountId)
    {
        Account account = accountManager.Find(accountId);
    
        if (account == null)
        {
            return new HttpNotFoundResult();
        }
    
        if (await authorizationService.AuthorizeAsync(User, document, "AccountAccess"))
        {
            return View(account);
        }
        else
        {
            return new ChallengeResult();
        }
    }
