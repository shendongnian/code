    var records = (from entry in db.Table1.AsQueryable();
                    orderby entry.Always_Prohibited                              
                    select new
                           {
                                 RowID = entry.RowID,
                                 VehicleMake = entry.Make,
                                 VehicleModel = entry.Model,
                                 Restricted = (entry.Always_Prohibited == null || entry.Always_Prohibited == "False") ? "Restricted" : "Not Restricted"
                           }).ToList();
