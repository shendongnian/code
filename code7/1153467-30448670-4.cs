    [Flags()]
    public enum AddressTypeValue : ushort
    {
        Personal = 0,
        Business = 1,
        POBox = 2,
        Inertnational = 4
    }
    public class Address
    {
        public AddressTypeValue AddressType { get; set; }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
 
        public Person() 
        {
            Address = new Address() { AddressType == AddressTypeValue.Personal };
        }
    }
