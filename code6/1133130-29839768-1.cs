    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
    public class Student : Person
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
