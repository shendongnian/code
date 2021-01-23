    public class Person : ICloneable
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Address PersonAddress { get; set; }
     
        public object Clone()
        {
            Person newPerson = (Person)this.MemberwiseClone();
            newPerson.PersonAddress = (Address)this.PersonAddress.Clone();
     
            return newPerson;
        }
    }
    public class Address : ICloneable
    {
        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
     
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    Person herClone = (Person)emilyBronte.Clone();
