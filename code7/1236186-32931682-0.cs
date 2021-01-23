    public string InternationalNumber
    {
        set { internationalNumber = value; }
        get { return internationalNumber ?? CalcInternationalNumber(); }
    }
