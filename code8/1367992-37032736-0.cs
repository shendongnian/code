    //Array of arrays validCartItems values for example
    byte[] offerKey1 = { 30, 163, 252, 225, 36, 208, 128, 47, 64, 244, 34, 199, 28, 57, 110, 215 };
    byte[] offerKey2 = { 31, 163, 254, 225, 35, 203, 119, 47, 65, 244, 24, 199, 28, 56, 110, 215 };
    byte[][] validCartItems = new byte[4][];
    validCartItems[0] = offerKey1;
    validCartItems[1] = offerKey1;
    validCartItems[2] = offerKey1;
    validCartItems[3] = offerKey2;
    
    //Example of ItemPrice in _dataContext.ItemPrices
    var itemPriceInFakeContext = new ItemPrice()
    {
        OfferKey = offerKey1, // use the same object
        //some other properties            
    };
    
    // add fake item price to data context
    _dataContext.ItemPrices.Add(itemPriceInFakeContext );
    
    var itemPrices = _dataContext
        .ItemPrices
        .Where(item => 
             item.UserID == user.UniqueID
             && itemsPartID.Contains(item.PartID)
             && validCartItems.Contains(item.OfferKey)
             && item.CurrencyID == defaultCurrencyCode
             && item.Inventory > 0)
        .ToList();
