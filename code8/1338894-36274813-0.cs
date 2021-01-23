    class StockItem
    {
        //StockItem Variables
        public static int LastStockNumber = 10000;
        internal int StockNumber;
        internal string Description;
        internal float CostPrice;
        //Constructor - Ignores static field and receives the StockNumber as a parameter
        public StockItem(int StockNumber, string Description, float CostPrice) 
        {
            this.StockNumber = StockNumber;
            this.Description = Description;
            this.CostPrice = CostPrice;
        }
        //Constructor -  Uses this static field to automatically generate a StockNumber and increments +1 to LastStockNumber
        public StockItem(string Description, float CostPrice) : this(StockItem.LastStockNumber, Description, CostPrice)
        {           
            this.StockNumber = LastStockNumber;
            LastStockNumber++;
            this.CostPrice = CostPrice;
            this.Description = Description;
        }
