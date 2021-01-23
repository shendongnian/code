    public object Clone()
    {
        Vehicle clone = this.MemberwiseClone();
        List<Order> clonedOrders = new List<Order>();
        foreach (Order order in this.FilledOrders)
            clonedOrders.Add((Order)order.Clone());
        clone.FilledOrders = clonedOrders;
        rreturn clone;
    }
