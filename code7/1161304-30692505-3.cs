    private static void Caller()
    {
        IOrder order;
        MakeOrder(out order);
    }
    private static void MakeOrder(out IOrder order)
    {
        order = new Order
        {
            PeriodCount = mciOrderInfo.PeriodCount,
            Quantity = mciOrderInfo.Quantity,
            ShoppingItemId = shoppingItem
        };
    }
