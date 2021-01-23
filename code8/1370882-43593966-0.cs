    public SpendingAccountSearchParams()
    {
        DateTime AsOfDate { get; set; } = DateTime.Now;
        int Skip { get; set; } = 0;
        int Top { get; set; } = 20;
    }
