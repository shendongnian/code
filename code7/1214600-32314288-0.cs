    var result = list.GroupBy(x => new { x.FirstName, x.LastName, x.Mobile, x.Email })
                     .Select(x => new 
                                     {
                                        Id = String.Join("|",x.Select(z => z.Id)),
                                        FirstName = x.Key.FirstName
                                        LastName = x.Key.LastName,
                                        Mobile = x.Key.Mobile,
                                        Email = x.Key.Email
                                     });
