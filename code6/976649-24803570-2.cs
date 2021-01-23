    enum OrderStatus {
        NewOrder = 1,
        OnHold = 6,
        CancelledOrder = 9,
        // Approval States
        WaitingApproval = 7,
        ApprovalRejected = 8,
     
        // Processing
        InQueue = 2,
        Handling = 3,
        // We've done our job!
        Shipping = 4,
        Received = 5
    }
