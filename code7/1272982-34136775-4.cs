    // Interface
    AbstractOrder IOrderService.GetById(int);
    // Service
    AbstractOrder OrderService.GetById(int id)
    {
        return new ServiceOrder(...);
    }
    // Client
    ClientOrder = (ClientOrder)IOrderService.GetById(42);
