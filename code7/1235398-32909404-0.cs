    class Product
    {
        public string Name { get; set; }
        public int ProductID { get; set; }
    }
    class Transaction
    {
        public string MyProperty { get; set; }
        public int TransactionID { get; set; }
    }
    class Connect
    {
        public int ProductID { get; set; }
        public int TransactionID { get; set; }
    }
