        var q = from a in context.Accounts
                join c in context.Contracts
                on a.Id equals c.AccountId
                group a by new { a.Name } into g
                select new AccountContracts
                {
                   AccountName = g.Key.Id,    // Account name
                   Contracts = g.SelectMany(x => x.Contracts)
                };
    
