    class StockItem
    {
      public static int LastStockNumber = 10000;
      public int StockNumber;
      public string Description;
      public float CostPrice;
      public StockItem(int StockNumber, string Description, float CostPrice) 
      {
        this.StockNumber = StockNumber;
        this.Description = Description;
        this.CostPrice = CostPrice;
      }
      public StockItem(string Description, float CostPrice): this(StockItem.LastStockNumber++, Description, CostPrice)
      {
      }
