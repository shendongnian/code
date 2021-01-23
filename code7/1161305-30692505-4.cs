    private static void Caller()
    {
        IOrder order = new Order();
        MakeOrder(order);
    }
    private static void MakeOrder(IOrder order)
    {
        order.PeriodCount = mciOrderInfo.PeriodCount;
        order.Quantity = mciOrderInfo.Quantity;
        order.ShoppingItemId = shoppingItem;
    }
