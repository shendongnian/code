        var q = from a in context.Accounts
                join c in context.Contracts
                on a.Id equals c.AccountId
                select new ContractAccounts
                {
                   Name = a.Name,    // Account name
                   Phone = c.Phone      // Contract Phone
                };
    
    private class ContractAccounts
    {
       public String Name { get; set;}
       public String Phone { get; set;}
    }
