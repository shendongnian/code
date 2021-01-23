    public CustomerRepository(Func<IForceClient> clientFunc)
    {
        _clientFunc = clientFunc;
    }
    public async Task<long> GetTotalContacts()
    {
        string totalContactCountQry = "some query"
        // calling _clientFunc() will provide you a new instance of IForceClient
        var customerCount =  await _clientFunc().QueryAsync<ContactsTotal>(totalContactCountQry);
        var firstOrDefault = customerCount.Records.FirstOrDefault();
        return firstOrDefault != null ? firstOrDefault.Total : 0;
    }
