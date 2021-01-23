    public class Customer
    {
        public string FullName {get;set;}
        public DateTime DateOfBirth {get;set;}
        public string Address {get;set;}
        public Customer NameOfCustomer(string Name)
        {
            this
                .FullName = Name;
            return 
                this;
        }
        public Customer Bornon(DateTime dateOfBirth)
        {
            this
                .DateOfBirth = dateOfBirth;
            return 
                this;
        }
        public void StaysAt(string Address)
        {
            this
                .Address = Address;
            eturn 
                this; 
        }
    } 
