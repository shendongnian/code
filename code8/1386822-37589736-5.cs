    var cust = item.Profiles.Select(c => new
                {
                    id = c.CustId,
                    Name = c.Name
                }).OrderByDescending(c => c.Name).ToList();
