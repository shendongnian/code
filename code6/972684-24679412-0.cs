    static class Global
    {
        private static List<Customer> customers = new List<Customer>();
        public static List<Customer> Customers
        {
            get { return customers; }
            set { customers = value; }
        }
    }
