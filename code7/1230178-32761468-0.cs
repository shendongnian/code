    var lines = new [] {
      contact.Name,
      contact.AddressLine1,
      contact.AddressLine2,
      contact.AddressLine3,
      contact.PostCode
    };
    var address = String.Join("<br/>", lines.Where(l => !String.IsNullOrWhitespace(l));
