    public class myclass
    {
        public Customer[] Customer { get; set; }
        public int number
        {
            get { return Customer.Length; }
        }
    }
