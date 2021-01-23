    var goodCusts = new List<Customer>();
    foreach(var customer in customers)
    {
        var testCust = customer;
        for (int i = testCust.Orders.Count - 1; i >= 0; i--) 
        {
            if (testCust.Orders[i].OrderItems.Count != 1)
                testCust.Orders.RemoveAt(i);
        }
        if (testCust.Orders.Any())
            goodCusts.Add(testCust);        
    }
