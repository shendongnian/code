    [HttpGet("[action]/{accountNumber}")]
    public async Task<IHttpActionResult> GetSubscriberHistory(string accountNumber)
    {
        SubscriberManager subsManager = new SubscriberManager();
        return await subsManager.GetSubscriberHistoryByAccountNumber(accountNumber);
    }
