    dynamic salesDetails = new ExpandoObject();
    salesDetails.Uid = 10;
    
    salesDetails.Sales = new ExpandoObject();
                
    salesDetails.Sales.France = new ExpandoObject();
    salesDetails.Sales.France.Paris = 50;
    salesDetails.Sales.France.Lyon = 25;
    
    salesDetails.Sales.UK = new ExpandoObject();
    salesDetails.Sales.UK.London = 75;
    
    salesDetails.Sales.Germany = new ExpandoObject();
    salesDetails.Sales.Germany.Berlin = 23;
    
    dynamic london = salesDetails.Sales.UK.London;
