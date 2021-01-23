    class HeavyStockItem : StockItem //Extended to StockItem Class
    {
        //Variable
        internal float Weight;
        //Constructor - Ignores static field and receives the StockNumber and adds Weight to the parameters
        public HeavyStockItem(int StockNumber, string Description, float CostPrice, float Weight): base(StockNumber, Description, CostPrice)
        {
            this.Weight = Weight;
        }
        //Constructor
        public HeavyStockItem(string Description, float CostPrice, float   Weight): base(Description, CostPrice)
        {
            this.Weight = Weight;
        }
