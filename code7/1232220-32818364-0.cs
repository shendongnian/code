    public class Customer {
        public int PK { get; set; }
        public string Email { get; set; }
        public string Name { get { return data.Value.Name; } set { ... } }
        public string Street { get { return data.Value.Street; } set { ... } }
        public string City { get { return data.Value.City; } set { ... } }
        private struct CustomerData
        {
            public string Name, Street, City;
        }
        private Lazy<CustomerData> data = new Lazy<CustomerData>(() => loadData());
    }
