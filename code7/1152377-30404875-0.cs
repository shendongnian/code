    from c in _db.Contracts
    let mostRecentContractLog = c.ContractLogs
                                 .OrderByDescending(cl => cl.date)
                                 .FirstOrDefault()
    select new { c, mostRecentContractLog }
