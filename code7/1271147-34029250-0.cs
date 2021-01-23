    private int price;
    private NumberFormatInfo info = new NumberFormatInfo
    {
        NumberDecimalSeparator = ","
    };
    public int Price
    {
      get { return price; }
      set { price = value; }
    }
    public string GetPrice
    {
        get
        {
            return (Price / 100d).ToString("##.00", info);
        }
    }
