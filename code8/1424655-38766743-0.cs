    private static Expression<Func<VendorPrice, PriceItem>> GetPriceSelector(
        Expression<Func<VendorPrice, decimal>> formula)
    {
        Expression<Func<VendorPrice, PriceItem>> expression = e => new PriceItem
        {
            Id = e.Id,
            Price = formula.Invoke(e) //use the forumla expression here
        };
        return expression.Expand(); //This causes formula.Invoke(e) to be converted 
                                    //to something like Math.Round(e.Price, 4)
    }
