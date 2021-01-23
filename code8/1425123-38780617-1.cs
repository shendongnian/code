        enum OrderType
        {
            TradeOrder,
            LibraryOrder
        }
        Dictionary<OrderType, Type> _orderTypeMap = new Dictionary<OrderType, Type>
        {
            { OrderType.LibraryOrder, typeof(LibraryOrder)},
            { OrderType.TradeOrder, typeof(TradeOrder)}
        };
        Order GetOrderInstance(OrderType orderType)
        {
            return Activator.CreateInstance(_orderTypeMap[orderType]) as Order;
        }
