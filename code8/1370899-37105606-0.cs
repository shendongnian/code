    [Table("PersonParameter")]
    public abstract class PersonParameter
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
    }
    public class Shirt : PersonParameter
    {
        [InverseProperty("Shirt")]
        public List<Person> Persons { get; set; }
    }
    public class Shoes : PersonParameter
    {
        [InverseProperty("Shoes")]
        public List<Person> Persons { get; set; }
    }
