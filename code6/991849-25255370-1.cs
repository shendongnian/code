    var q = from a in context.Accounts
            join c in context.Contracts on a.Id equals c.AccountId
            group a by new { a.Id, a.Name, a.Etc } into g
            select new CustomAccount
            {
                Id = g.Key.Id,
                Name = g.Key.Name,
                Etc = g.Key.Etc,
                Contracts = g.SelectMany(x => x.Contracts)
            };
