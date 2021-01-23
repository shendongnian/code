       class CustomerList
        {
            private List<Customer> _list = new List<Customer>();
    
            public void Register(string user, string password)
            {
                _list.Add(new Customer(user, password));
            }
    
            public bool CanLogin(string user, string password)
            {
                return _list.Contains(new Customer(user, password));
            }
        }
    
        public class Customer
        {
            public string Name { get; protected set; }
            public string Pass { get; set; }
    
            public Customer(string username, string password = "")
            {
                Name = username;
                Pass = password;
            }
    
            public bool Equals(Customer other)
            {
                if (other == null)
                    return false;
    
                return this.Name == other.Name;
            }
    
            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                Customer customerObj = obj as Customer;
                if (customerObj == null)
                    return false;
                else
                    return Equals(customerObj);
            }
    
            public override int GetHashCode()
            {
                return this.Name.GetHashCode();
            }
    
            public static bool operator ==(Customer person1, Customer person2)
            {
                if (((object)person1) == null || ((object)person2) == null)
                    return Object.Equals(person1, person2);
    
                return person1.Equals(person2);
            }
    
            public static bool operator !=(Customer person1, Customer person2)
            {
                return !(person1 == person2);
            }
        }
    
    
        private void button30_Click(object sender, EventArgs e)
        {
            CustomerList ss = new CustomerList();
            ss.Register("Tony", "xx");
    
            if (ss.CanLogin("Tony", "xx"))
            {
                Console.WriteLine("Passed");
            }
        }
