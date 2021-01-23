    public class Customer : IComparable<Customer>
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Customer(int age, string firstName, string lastName)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }
        public int CompareTo(Customer other)
        {
            return Age.CompareTo(other.Age);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer(25,"a","b"),
                new Customer(21,"c","d"),
                new Customer(22,"e","f"),
                new Customer(28,"g","i"),
                new Customer(30,"j","k"),
                new Customer(23,"l","m"),
                new Customer(31,"a","b"),
            };
            customers.Sort();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Age);
            }
            Console.ReadKey();
        }
    }
