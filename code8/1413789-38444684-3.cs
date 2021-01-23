    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
        public override string ToString()
        {
            return String.Format("Name = {0}, Address = {1}, Country = {2}, Continent = {3}", Name,Address,Country,Continent);
        }
    }
