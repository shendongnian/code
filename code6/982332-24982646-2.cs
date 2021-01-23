    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee
            {
                name = "Joe",
                Addresses = new List<Address>
                {
                    new Address { id = 1, location = "foo", postcode = "bar" },
                    new Address { id = 2, location = "baz", postcode = "quux" }
                }
            };
            string json = JsonConvert.SerializeObject(emp);
            Console.WriteLine(json);
        }
    }
