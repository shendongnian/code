    private string latitude;
    public string Latitude
    {
        get
        {
            NumberFormatInfo format = new System.Globalization.NumberFormatInfo();
            format.CurrencyDecimalDigits = 2;
            format.CurrencyDecimalSeparator = ",";
            format.CurrencyGroupSeparator = "";
            return decimal.Parse(latitude).ToString(format);
        }
        set
        {
            latitude = value;
        }
    }
        
