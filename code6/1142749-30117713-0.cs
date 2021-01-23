    var query = from visit in db.Visits
    
                        join address in db.Addresses on visit.AddressId equals address.Id
    
                        group address by new {
                            address.Name,
                            address.Prename,
                            address.Street,
                            address.StreetNr,
                            address.Zip,
                            address.ZipLong,
                            visit.VisitNr
                        } into temp
                    select  new {
                        Name = temp.Key.Name,
                        Prename = temp.Key.Prename,
                        Street = temp.Key.Street,
                        StreetNr = temp.Key.StreetNr,
                        Zip = temp.Key.Zip,
                        ZipLong = temp.Key.ZipLong,
                        VisitNr = temp.Key.VisitNr,
                        RecCount = temp.Count()
                    };
    
                var list = query.Where(x => x.RecCount > 1).ToList();
