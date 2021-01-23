    [DelimitedRecord(",")]
    public class Orders
    {
        public string Name;
        public string Track;
        public string Price;
        [FieldOptional]
        public string Product
        [FieldOptional]
        public string BasePrice
        [FieldOptional]
        public string ShipPrice
        [FieldOptional]
        public string TotalPrice
    }
