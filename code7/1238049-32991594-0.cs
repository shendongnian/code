    var t1 =  (from cn in contracts
                   join cl in client on cn.Id equals cl.Id
                   join so in siteObject on cn.Id equals so.ContractId
    			   group cl.Id by p.PersonId into g
                   select new
                   {
                         siteObjId = string.Join("," g.ToArray()),
                         clientId = g.Key
                    }).ToList();
