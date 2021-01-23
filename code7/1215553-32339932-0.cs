    var clientEmployees = db.Clients.Where(x => x.Firm == firm)
                            .Select(a => new ClientEmployees {
                                Id = a.Id,
                                Name = a.Name,
                                etc..
                            })
                            .ToList(); 
