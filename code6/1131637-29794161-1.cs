     var  business= db.business 
    				  .GroupJoin(
    						db.permissions,
    						bus => bus.busid,
    						perm => perm.perm_busid,                  
    						(bus, perm) => new { bus, perm })
    				  .SelectMany(
    					  z => z.permissions.DefaultIfEmpty(),
    					  (x, y) => new { Business = x.Bus, Permission = y })
    				  .Where(z => z.Permission.anotherid == 17)
    				  .Select(s => new DTO_business
    				  {
    					  BusinessID = s.Business.busid.Convert(),
    					  BusinessName = s.Business.busname.Convert()
    				  });
