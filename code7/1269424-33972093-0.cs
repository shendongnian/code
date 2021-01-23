    string price = "1,1,2,3.23";
    decimal priceParse = 0;
    
    if (decimal.TryParse(price, out priceParse))
    {
         string shouldBeFormat = Convert.ToDecimal(priceParse).ToString("#,##0.00");
         
         if (price == shouldBeFormat)
         {
            // your good
         }
         else
         {
            // no good
         }
    }
