	if (LastReceivableAmount == null)
    {
    	Row.PreviousReceivableAmount_IsNull = true;
    }
    else
    {
    	Row.PreviousReceivableAmount = LastReceivableAmount.GetValueOrDefault();
    }
	if (!Row.ReceivableAmount_IsNull || Row.CustomerID != LastCustomerID)
    {
        Row.PreviousReceivableAmount = LastReceivableAmount.GetValueOrDefault();
        LastReceivableAmount = Row.ReceivableAmount;
    }
    
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
	if (LastPaymentDate == null)
    {
    	Row.PreviousPaymentDate_IsNull = true;
    }
    else
    {
    	Row.PreviousPaymentDate = LastPaymentDate.GetValueOrDefault();
    }
    if (!Row.PaymentAmount_IsNull == true || Row.CustomerID != LastCustomerID)
    {
        Row.PreviousPaymentDate = LastPaymentDate.GetValueOrDefault();
        LastPaymentDate = Row.Date; 
    }
