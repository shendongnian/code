    [HttpGet("[action]/{accountNumber}")]
    public async Task<List<SubscriberHistory>> GetSubscriberHistory(string accountNumber)
    {
        SubscriberManager subsManager = new SubscriberManager();
        return await subsManager.GetSubscriberHistoryByAccountNumber(accountNumber);
    }
