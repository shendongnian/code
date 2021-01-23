    Expression<Func<Customer, bool>> myRuntimeExpression = null;
    
    if(condition1)
    {
        myRuntimeExpression = cust => cust.Categories.Any(cat => cat.Code == "Retial"); // or some local variable
    }
    else if(condition2)
    {
        myRuntimeExpression = cust => cust.Categories.Any(cat => cat.Id = someId) == false;
    }
    else if(condition3)
    {
    
    }
    
    var query = DB.Customers.Where(myRuntimeExpression);
