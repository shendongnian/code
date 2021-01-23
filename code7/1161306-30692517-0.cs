    private static void Caller()
    {
        IOrder order = MakeOrder(order);
    }
    
    private static IOrder MakeOrder()
    {
        return new Order
        {
            PeriodCount = mciOrderInfo.PeriodCount,
            Quantity = mciOrderInfo.Quantity,
            ShoppingItemId = shoppingItem
        };
    }
