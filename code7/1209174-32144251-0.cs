    public int NoOfProcessed
    {
        get
        {
            return ProcessedItem;
        }
        private set
        {
            ProcessedItem = value;
            if (MaximumLimitToStopRequest != null)
            {
                MaximumLimitToStopRequest(this, ProcessedItem);
            }
        }
    }
