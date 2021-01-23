     namespace MyProjects.SignalR.Hubs
    {
        public class OrdersHub : Hub
        {
    
    
            public void OrderDeleted(int manufacturerId, int orderId)
            {
                Clients.Group(OrdersGroup(manufacturerId)).BroadcastOrder(orderId);
            }
    
    
            public Task JoinOrders(int manufacturerId)
            {
                return Groups.Add(Context.ConnectionId, OrdersGroup(manufacturerId));
            }
    
            private string OrdersGroup(int manufacturerId)
            {
                return "orders" + manufacturerId;
            }
    
        }
    }
