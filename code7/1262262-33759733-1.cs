    var query = from clients in db.Clients
                            join cdl in db.Client_Details_Legacy on cdl.Id = clients.Client_Details_Legacy_Id
                            join pp in db.Policies_Property on pp.Client_Id = clients.Id
                where pp.CoverTo >= CoverToStart && pp.CoverTo <= CoverToEnd
                select new { 
    				FullName = cdl.FullName, 
    				AddressLine1 = cdl.AddressLine1, 
    				AddressLine2 = cdl.AddressLine2, 
    				AddressLine3 = cdl.AddressLine3, 
    				PolicyNumber = pp.PolicyNumber,
    				CoverTo = pp.CoverTo,
    				Id = clients.Id
    				};
    return query.OrderBy(q => q.Id).ToList();
				
