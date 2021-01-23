    public async Task<bool> ListSubscribeAsync(string emailAddress, string apiKey, string listId)
    {
      try
      {
        var api = new MailChimpManager(apiKey);
        var profile = new Member();
        profile.EmailAddress = emailAddress;
        var output = await api.Members.AddOrUpdateAsync(listId, profile);
        return true;
      }
      catch (Exception ex)
      {
        logger.Error("An error ocurred in trying to Subscribe to Mailchimp list. {0}", ex.Message);
        return false;
      }
    }
