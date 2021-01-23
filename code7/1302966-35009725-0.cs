    [Flags]
    public enum PurchaseOrderStatus
    {
        None = 0,
        Sent = 1 << 0, // 1
        Received = 1 << 1, // 2
        Enrolled = 1 << 2, // 4
    }
