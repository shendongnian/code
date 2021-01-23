    var results = (from TBL.OfferMaster
                select new
                {
                    PrimaryID = OM.OfferID,
                    Address = String.Join(", ", (new string[] { OM.StreetAddress, OM.City, OM.State, OM.Country, OM.ZipCode })
                                                    .Where(x => !String.IsNullOrWhiteSpace(x))),
                }).ToList();
