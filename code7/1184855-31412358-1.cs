    [Flags]
    public enum Status
    {
        Open = 0x01,
        Completed = 0x02,
        Rescheduled = 0x04,
        Canceled = 0x08,
        Started = 0x10,
        Customer_Notified = 0x20,
        Do_Not_Move = 0x40,
        Needs_Confirmation = 0x80
    }
