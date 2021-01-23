    decimal sum = 0;
    foreach (var item in db.Bars)
    {
        if (item.Pricelist != null && item.Pricelist.Price != null)
        {
            sum +=  item.Quantity * item.Pricelist.Price;
        }
        else
        {
            //Check this specific item from db.Bars which may have an inconsistent state
        }
    }
