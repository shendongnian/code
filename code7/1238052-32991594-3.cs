    var groupResult =  (from cn in contracts
                       join cl in client on cn.Id equals cl.Id
                       join so in siteObject on cn.Id equals so.ContractId
       			       group cl.Id by cl.Id into g
                       select new {
                            ClientId = g.Key,
                            Result = g
                       }).ToList();
