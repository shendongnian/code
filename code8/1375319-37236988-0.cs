    public void CloneOrder(int orderId)
        {
            using (var database = new MyDbContext())
            {
                Order order = db.Orders.Find(m => m.Id == orderId);
                var newOrder = new Order{
                    Content = order.Content
                }
    
                database.Orders.Add(newOrder);
    
                OrderDetail orderDetail = db.OrderDetails.Find(x => x.OrderId == orderId);
                orderDetail.OrderId = newOrder.Id;
                database.OrderDetails.Add(orderDetail);
                database.SaveChanges();
            }
        }
