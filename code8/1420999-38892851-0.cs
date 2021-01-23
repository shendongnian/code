    [NotMapped]
    public long LongClientId
    {
        get { return BitConverter.ToInt64(this.ClientId, 0); }
        set { this.ClientId = BitConverter.GetBytes(value); }
    }
