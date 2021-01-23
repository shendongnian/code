    public OrderDetail Detail
    {
        get
        {
            return this.OrderDetails
                .OrderByDescending(od => od.ChangedAt)
                .FirstOrDefault();
        }
    }
