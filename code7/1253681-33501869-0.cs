    var array = new List<object>();
    var offers = new[]
    {
        new {ItemName = itnme, Price = price, Quantity = quant}
        ...
    };
    array.Add(new
        {
            Dealname = dealname,
            Ticketcount = tictnum,
            OriginalPrice = origpri,
            Dealsticketcount = dealsticktnu,
            dealprice = dp,
            totalprice = totamnt,
            Offers = offers  // adding Offers as a property here
        });
