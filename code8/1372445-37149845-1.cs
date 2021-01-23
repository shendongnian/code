    public int QuoteQuantity
    {
        get 
        {
            int qty = 0;
            if (!string.IsNullOrWhiteSpace(QuoteQuantityAsString))
            {
                int.TryParse(QuoteQuantityAsString, out qty);
            }
            return qty;
        }
    }
    public string QuoteQuantityAsString { get; set; }
    // You will then need to use the
    // QuoteQuantityAsString property in your View, instead
