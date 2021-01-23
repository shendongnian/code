    public long date;
    public DateTime Date
    {
        get
        {
            return DateTime.FromBinary(date);
        }
        set
        {
            date = value.ToBinary();
        }
    }
