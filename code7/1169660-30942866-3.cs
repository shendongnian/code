    var deliveryAddress = order.Elements(ns + "Addresses")
        .Elements(ns + "Delivery")
        .Select(e => new Invoice.Address
        {
            Street = (string)e.Element(ns + "Street"),
            // ....
        })
        .Single();
