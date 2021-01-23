    var array = new List<object>();
    var offers = new List<object>();
    offers.Add(new
           {
          ItemName = itnme,
          Price = price,
          Quantity = quant,
          });
    
    array.Add(new
            {
            Dealname = dealname,
            Ticketcount = tictnum,
            OriginalPrice = origpri,
            Dealsticketcount = dealsticktnu,
            dealprice = dp,
            totalprice = totamnt,
            Offers = offers
            });
