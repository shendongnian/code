    var query = ...
        .Select(x => new AccountRoot
        {
            // add copy properties here
            // ....
            Providers = x.Providers
                            .Select(y =>
                            {
                                // Here we can construct completely new entity, 
                                // with copying all properties one by one,
                                // or just reorder existing collection as I do here
                                var result = y;
                                result.Accounts = y.Accounts.OrderBy(z => z.Name).ToArray();
                                return result;
                            })
                            .OrderBy(y => y.Name)
                            .ToArray()
        })
        .ToArray();
