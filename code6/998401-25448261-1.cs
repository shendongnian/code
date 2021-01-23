    var query = ...
        .Select(x => new AccountRoot
        {
            AccountRootId = x.AccountRootId,
            // Other properties to copy
            // ...
            Providers = x.Providers
                            .Select(y => new Hoster
                            {
                                HosterId = y.HosterId,
                                // Other properties to copy
                                // ...
                                Accounts = y.Accounts.OrderBy(z => z.Name).ToArray(),
                            })
                            .OrderBy(y => y.Name)
                            .ToArray()
        })
        .ToArray();
