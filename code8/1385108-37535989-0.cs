    var ord = new Order()
        {
             ...
        };
    foreach (var item in cart)
    {
        var itemOrder = new OrderItem
        {
             ...
         };
       order.orderDetails.Add(itemOrder);
    }
    db.Orders.Add(ord);
