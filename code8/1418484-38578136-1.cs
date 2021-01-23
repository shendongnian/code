    // Build your Dispatches with related information
    var dispatchModels = db.Dispatches.AsEnumerable()
                                      .Select(d => new DispatchViewModel()
                                      {
                                          Dispatch = d,
                                          City = db.Cities.FirstOrDefault(c => c.CityId == d.CityId),
                                          Client = db.Clients.FirstOrDefault(c => c.ClientId == d.CustomerId),
                                          ...
                                      });
