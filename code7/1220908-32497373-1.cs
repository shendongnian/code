    var amount = dealingContext.vw_GetContribution
                .Where(o => o.ContactID == contactId)
                .GroupBy(o=> new { o.CurrentFinancialYear, o.Amount})
                .Select(group =>
                       new { 
                          year= group.Key.CurrentFinancialYear, 
                          sum= group.Sum(x=>x.Amount) 
                           });
                        
