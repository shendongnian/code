    ...
    db.Orders.Add(order);
    db.SaveChanges(); 
    SummaryVm summaryVm = new SummaryVm
    { 
        email = order.user.UserName, 
        orderID = order.OrderID,
        tickets = model.Tickets, 
        totalPrice = total, 
        eventID=model.EventID,
             stripePublishableKey=ConfigurationManager.AppSettings["stripePublishableKey"]
    };
    return RedirectToAction("OrderSummary", "Order", summaryVm);
