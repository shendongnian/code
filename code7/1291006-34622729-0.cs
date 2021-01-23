    var existingBorrower = from s in db.ExistingBorrower select s.client_Name;
    
    var newBorrowers = db.AllClients
                       .GroupJoin(existingBorrower.ToList(), 
                                  i => i.CLIENT_NAME, 
                                  o => o.CLIENT_NAME,
                                  (allClient, brrower) => new {allClient, brrower})
                       .SelectMany(z => z.brrower.DefaultIfEmpty(),
                          (x, y) => new
                            {
                                ClientName = x.allClient.CLIENT_NAME,
                                Brrower = y
    
                            }).Where(b => b.Brrower == null);
