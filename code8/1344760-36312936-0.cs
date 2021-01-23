    class Customer
    {
        //Constructor
        public Customer(int customerID, string companyName, string contactName, string address, string city)
        {
            CustomerID = customerID;
            CompanyName = companyName;
            ContactName = contactName;
            Address = address;
            City = city;
            OrderList = new List<Order>();
        }
        public List<Order> OrderList { get; set; }
        // The CustomerID should not be available in the designer
        [Browsable(false)]
        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        // Set display name, which should be used in the designer
        [DisplayName("Name")]
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
    // The "Order" class represents a single order of a customer
    class Order
    {
        //Constructor
        public Order(int orderID, DateTime orderDate, string shipName, string shipCountry, double price)
        {
            OrderID = orderID;
            OrderDate = orderDate;
            ShipName = shipName;
            ShipCountry = shipCountry;
            Price = price;
        }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public double Price { get; set; }
        // Explicitly set a barcode field type
        [FieldType(LlFieldType.Barcode_EAN128)]
        public string PriceEan
        {
            get { return Price.ToString(); }
        }
    }
