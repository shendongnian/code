    public class Customer
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public Customer NameOfCustomer(string name)
        {
            this.FullName = name;
            return this;
        }
        public Customer BornOn(DateTime dateOfBirth)
        {
            this.DateOfBirth = dateOfBirth;
            return this;
        }
        public void StaysAt(string address)
        {
            this.Address = address;
            return this;
        }
    } 
