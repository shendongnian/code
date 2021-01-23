    if(newOrderSingle is QuickFix.FIX44.NewOrderSingle)
    {
        QuickFix.FIX44.NewOrderSingle ord44 = (QuickFix.FIX44.NewOrderSingle)newOrderSingle;
        // from here on you can work with ord44:
        ord44.Set(new Price(limitPrice));
        // more code which uses ord44
    }
