    private static void Caller()
    {
        IOrder order = MakeOrder();
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
