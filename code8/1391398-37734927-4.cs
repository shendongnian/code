    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            return customer != null && Equals(customer);
        }
        protected bool Equals(Customer other)
        {
            return string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((FirstName?.GetHashCode() ?? 0)*397) ^ (LastName?.GetHashCode() ?? 0);
            }
        }
    }
