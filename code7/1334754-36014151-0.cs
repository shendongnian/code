    public string ValidFromString { get; set; }
    public DateTime ValidFrom
    {
        get
        {
            DateTime validFrom;
            return DateTime.TryParse(ValidFromString, out validFrom)
                ? validFrom
                : default(DateTime);
        }
        set { ValidFromString = value.ToString("MMM-yyyy"); }
    }
