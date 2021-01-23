    ISession session = new SessionProvider("connectionstring").GetSession();
    OrderStatus status = session.Query<OrderStatus>().FirstOrDefault(os => os.Name.Equals("Processing"));     
    foreach (PurchaseOrder order in list.Select(o => o.PurchaseOrder))
    {
        order.OrderStatus = status;
        session.Save(order);               
    } 
    session.Flush();
