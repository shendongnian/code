               List<List<object>> Invoices = new List<List<object>>() {
                   new List<object>(){"a", 1}, 
                   new List<object>(){"b", 2}, 
                   new List<object>(){"c", 3}, 
                   new List<object>(){"d", 4}
                };
                List<List<object>> Accounts = new List<List<object>>() {
                   new List<object>(){"a", 100}, 
                   new List<object>(){"c", 101}
                };
                var results = (from invoices in Invoices
                              join accounts in Accounts on invoices[0] equals accounts[0]
                              select new { name = invoices[0], id = invoices[1], total = accounts[1] })
                              .ToList();​
