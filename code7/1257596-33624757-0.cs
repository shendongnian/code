      String propertyName = "AmountDue";
    
      var result = _context
        .Invoices
        .Find()
        .Where(c => c.Contact.Id == contactId)
        .OrderBy(item => typeof(Invoice).GetProperty(
             propertyName, 
             BindingFlags.Public | BindingFlags.Instance)
           .GetValue(item))
        .ToList();
