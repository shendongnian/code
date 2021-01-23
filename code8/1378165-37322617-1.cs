    [HttpGet("[action]/{accountNumber}")]
    public List<SubscriberHistory> GetSubscriberHistory(string accountNumber)
    {
        SubscriberManager subsManager = new SubscriberManager();
        return subsManager.GetSubscriberHistoryByAccountNumber(accountNumber);
    }
