    MyDbEntities mydb = new MyDbEntities();
    Order order = new Order();
    order.OrderID = "m0000001";
    try
    {
        mydb.Order.Add(order);
        mydb.SaveChange();
    }
    catch (Exception exception)
    {
        if(excpetion == duplicate key) // pseudo code, don't know the error for duplicate keys
        {
            order.OrderID = m0000002;
        }
    }
