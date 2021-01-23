    public async Task<IActionResult> View(int accountId)
    {
        Account account = accountManager.Find(accountId);
    
        if (account == null)
        {
            return new HttpNotFoundResult();
        }
    
        if (await authorizationService.AuthorizeAsync(User, account, Operations.Read))
        {
            return View(account);
        }
        else
        {
            return new ChallengeResult();
        }
    }
