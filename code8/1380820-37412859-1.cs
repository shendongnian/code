    public async Task<OzCpAddOrUpdateEmailAddressToListOutput> 
        AddOrUpdateEmailAddressToList(
            OzCpAddOrUpdateEmailAddressToListInput aParams)
    {
        var result = new OzCpAddOrUpdateEmailAddressToListOutput();
        try
        {
            var mailChimManager = new MailChimpManager(aParams.MailChimpApiKey);
            Member mailChimpResult =
                await mailChimManager.Members.AddOrUpdateAsync(
                    aParams.Listid, 
                    new Member                                                                                                     
                    {
                        EmailAddress = aParams.EmailAddress
                    });
        }
        catch (Exception ex)
        {
            result.ResultErrors.AddFatalError(PlatformErrors.UNKNOWN, ex.Message);
        }
        return result;
    }
