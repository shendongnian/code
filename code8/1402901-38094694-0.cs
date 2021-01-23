    var results = (from TBL.OfferMaster.AsEnumerable()
                    let addresses = new string[] { OM.StreetAddress, OM.City, OM.State, OM.Country, OM.ZipCode }
                    select new
                    {
                        PrimaryID = OM.OfferID,
                        Address = String.Join(", ", addresses.Where(x => !String.IsNullOrWhiteSpace(x))),
                    }).ToList();
