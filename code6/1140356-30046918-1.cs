    var data = (from dt in searchByPhone
                        let cl = clientList.Where(z => z.phones.Any(y => y.phoneno.Equals(dt.Item1)))
                        select cl.Select(x => new ClientObject
                                                  {
                                                      firstname = x.firstname,
                                                      lastname = x.lastname,
                                                      id = x.id,
                                                      phonenumber = dt.Item1,
                                                      message = dt.Item2
                                                  })).Aggregate((a, b) =>
                                                  {
                                                      a.ToList().AddRange(b);
                                                      return a;
                                                  });
    
