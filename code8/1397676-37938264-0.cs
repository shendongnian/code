        orderID = newOrder.OrderID;
       //Ord is the name of the List...
        if (Ord.Count == 0)
        {
            OrderRepository ordRepo = new OrderRepository();
            newOrder = new Order();
            newOrder.OrderID = orderID;
            ordRepo.NewOrder(newOrder);
        }
     Ord.Add(new OrderDetail() { OrderID = newOrder.OrderID, ItemID = prodDict[b.Text], Price = priceDict[b.Text], Quantity = Convert.ToDecimal(QuantityTextBox.Text) });
