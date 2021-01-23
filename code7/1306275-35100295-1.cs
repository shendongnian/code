    if (oUnitPrice == null || Convert.IsDbNull(oUnitPrice)) 
    {
       // no nows or PromotionalPrice column is null
    }
    else
    {
       // if oUnitPrice is not decimal 
       // but it can be converted to decimal it will work
       decUnitPrice = Convert.ToDecimal(oUnitPrice);
    }
