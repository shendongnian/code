    if (LastSaleDate == null)
    {
        Row.PreviousSaleDate_IsNull = true;
    }
    else
    {
        Row.PreviousSaleDate = LastSaleDate.GetValueOrDefault();
    }
	if (!Row.SaleAmount_IsNull || Row.CustomerID != LastCustomerID)
    {
        LastSaleDate = Row.Date;
    }
