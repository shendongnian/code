    var largeset =
      from invs in context.Invoices
      join lines in context.InvoiceLines on invs.InvoiceId equals lines.InvoiceId
      join tracks in context.Tracks on lines.TrackId equals tracks.TrackId
      group new { invs, lines, tracks }
      by new
      {
          invs.InvoiceId,
          invs.InvoiceDate,
          invs.CustomerId,
          invs.Customer.LastName,
          invs.Customer.FirstName
      } into grp
      select new
      {
          InvoiceId = grp.Key.InvoiceId,
          InvoiceDate = grp.Key.InvoiceDate,
          CustomerId = grp.Key.CustomerId,
          CustomerLastName = grp.Key.LastName,
          CustomerFirstName = grp.Key.FirstName,
          CustomerFullName = grp.Key.LastName + ", " + grp.Key.FirstName,
          TotalQty = grp.Sum(l => l.lines.Quantity),
          TotalPrice = grp.Sum(l => l.lines.UnitPrice),
          Tracks = grp.Select(t => t.tracks)
      };
