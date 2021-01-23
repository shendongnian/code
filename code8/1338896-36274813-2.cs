    class CarEngine : HeavyStockItem //Extended to HeavyStockItem Class
    {
        //Variables
        internal string EngineNumber;
        //Constructor
        public CarEngine(int StockNumber, string Description, float CostPrice, float Weight, string EngineNumber): base(StockNumber, Description, CostPrice, Weight)
        {
            this.EngineNumber = EngineNumber;
        }
        //Constructor
        public CarEngine(string Description, float CostPrice, float Weight, string EngineNumber): base(Description, CostPrice, Weight)
        {
            this.EngineNumber = EngineNumber;
        }
