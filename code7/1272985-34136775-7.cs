    // Interface
    Order IOrderService.GetById(int);
    // Service
    Order OrderService.GetById(int id)
    {
        return new Order(...);
    }
    // Client
    Order order = IOrderService.GetById(42);
    order.Repository = new ClientRepository(...);
    order.Submit();
