    class Customer
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }
    class Order
    {
        public int KeyCode { get; set; }
        public string Product { get; set; }
    }
    class Result
    {
        public string Name { get; set; }
        public IEnumerable<Order> Collection { get; set; }
        public Result(string name, IEnumerable<Order> collection)
        {
	        this.Name = name;
	        his.Collection = collection;
        }
    }
