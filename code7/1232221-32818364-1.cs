        public class Customer
        {
            public int PK { get; set; }
            public string Email { get; set; }
            public string Name { get { return data.Value.Name; } }
            public string Street { get { return data.Value.Street; } }
            public string City { get { return data.Value.City; } }
            public Customer()
            {
                data = new Lazy<CustomerData>(loadData);
            }
            private CustomerData loadData()
            {
                ...
            }
            private struct CustomerData
            {
                public string Name, Street, City;
            }
            private Lazy<CustomerData> data;
        }
