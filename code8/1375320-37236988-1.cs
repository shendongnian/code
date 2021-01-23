    public void CloneOrder(int orderId)
        {
            using (var database = new MyDbContext())
            {
                Order order = db.Orders.Find(m => m.Id == orderId);
                var newOrder = new Order{
                    Content = order.Content
                }
    
                database.Orders.Add(newOrder);
    
                OrderDetail orderDetail = new OrderDetail{
                    OrderId = newOrder.Id,
                    Content = order.OrderDetails.Content
                };
                database.OrderDetails.Add(orderDetail);
                database.SaveChanges();
            }
        }
