    Track defaultTrack= new Track()
            {
                TrackId = 0,
                TrackName = "No Track",
                TrackPrice = 0,
                Artist = "No Artist",
            };
     //Left outer join
     var screenset =
     from inv in context.Invoices where inv.InvoiceId == invoiceID
     from j in context.Invoices where j.InvoiceId == invoiceID
     join line in context.InvoiceLines on j.InvoiceId equals line.InvoiceId
     join track in context.Tracks on line.TrackId equals track.TrackId into trackGroup
     from trackDetails in trackGroup.DefaultIfEmpty(defaultTrack)
     select new InvoiceAndItemsDTO
     {
       InvoiceId = inv.InvoiceId,
       InvoiceDate = inv.InvoiceDate,
       InvoiceTotal = inv.Total,
       CustomerId = inv.CustomerId,
       CustomerFullName = inv.Customer.LastName + ", " + inv.Customer.FirstName,
       CustomerPhoneNumber = inv.Customer.Phone,
       InvoiceLineId = line.InvoiceLineId,
       TrackId = trackDetails .TrackId,
       TrackName = trackDetails .Name,
       TrackPrice = trackDetails .UnitPrice,
       Artist = trackDetails .Album.Artist.Name,
       UnitPrice = line.UnitPrice,
       Quantity = line.Quantity,
       Action = "None"
     };
