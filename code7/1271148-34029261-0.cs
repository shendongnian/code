    private int priceInPence;
    public decimal priceInPounds {
       get { return priceInPence / 100m; }
       set { priceInPence = (int)(value * 100); }
    }
