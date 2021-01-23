    private string latitude;
    public string Latitude
    {
        get
        {
            NumberFormatInfo format = new System.Globalization.NumberFormatInfo();
            format.CurrencyDecimalSeparator = ",";
            return decimal.Parse(latitude).ToString(format);
        }
        set
        {
            latitude = value;
        }
    }
        
