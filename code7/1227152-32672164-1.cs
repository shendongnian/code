           private static void Main(string[] args)
        {
            var addressContainer = new AddressContainer();
            var fields = addressContainer.GetType().GetFields();
            List<Address> lst = new List<Address>();
            foreach (var field in fields)
            {
                //print varialbe name
                Console.WriteLine(field.Name);
                var theValue = field.GetValue(addressContainer);
                if (theValue is Address) lst.Add((Address) theValue);
            }
            //spit out the collected address street values
            foreach (var address in lst)
            {
                Console.WriteLine(address.Street);
            }
            Console.ReadLine();
        }
    }
    public class AddressContainer
    {
        public Address ad1 = new Address() { Street = "Papanikolaou 3" };
        public Address ad2 = new Address() { Street = "Papanikolaou 7" };
    }
    public class Address
    {
        public string Street { get; set; }
    }
