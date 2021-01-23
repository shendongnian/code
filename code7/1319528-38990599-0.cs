    var customerID = 86795;
    var query = await _context.Contacts
                      .Where(g => g.CustomerID == customerID)
                      .Select(cntct=> new
                      {
                         contact = cntct,
                         address = cntct.Address.Where(p => p.AddressTypeID == 1),
                         city    = cntct.Address.Where(p => p.AddressTypeID == 1)
                                                .Select(h=>h.City),
                      }.ToList();
