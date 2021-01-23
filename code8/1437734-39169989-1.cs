    public ActionResult MySharedAction()
    {
        Account account = _accountRepository.GetAccountByEmail(System.Web.HttpContext.Current.User.Identity.Name);
        List<Campaign> campaigns = _campaignRepository.GetCampaignsByAccountId(account.AccountId);
        LayoutModel model = new LayoutModel
        {
            AccountId = account.AccountId,
            Email = account.Email,
            Name = account.Name,
            LogoPath = account.LogoPath,
        };
        foreach (Campaign campaign in campaigns)
        {
            model.AddCampaigns(campaign);
        }
        return PartialView(model);
    }
