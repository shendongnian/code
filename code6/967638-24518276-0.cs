    var result = components.Values.Aggregate(
        new { BidTotal = 0m, AskTotal = 0m, CloseTotal = 0m },
        (a, c) => new
        {
            BidTotal = a.BidTotal + c.BidPrice * c.Pricingshares,
            AskTotal = a.AskTotal + c.AskPrice * c.Pricingshares,
            CloseTotal = a.CloseTotal + c.ClosePrice * c.Pricingshares
        });
