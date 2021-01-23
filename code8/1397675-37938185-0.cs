    public void ButtonClickEvent(object sender, EventArgs e)
        {
            orderID = newOrder.OrderID;
           //Ord is the name of the List...
            if (Ord.Count == 0)
            {
               
                OrderRepository ordRepo = new OrderRepository();
                newOrder = new Order();
                newOrder.OrderID = orderID;
                ordRepo.NewOrder(newOrder);
        
            }
          
            newDetail= CreateOrderDetails(newOrder, b);
            Ord.Add(newDetail);
 
      private OrderDetail CreateOrderDetails(Order order, Button b)
        {
            var prodDict = db.Items.Select(t => new { t.Name, t.ItemID })
                  .ToDictionary(t => t.Name, t => t.ItemID);
            var priceDict = db.Items.Select(t => new { t.Name, t.Price })
                   .ToDictionary(t => t.Name, t => t.Price);
            OrderDetail ord = new OrderDetail();
          
            ord.OrderID = newOrder.OrderID;
            ord.ItemID = prodDict[b.Text];
            ord.Price =  priceDict[b.Text];
            ord.Quantity = Convert.ToDecimal(QuantityTextBox.Text);
            totalCost += ord.Price * ord.Quantity;
                
             return ord;
      }
     
