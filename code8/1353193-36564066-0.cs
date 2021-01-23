    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Other properties as desired
        public override string ToString()
        {
            return Name ?? "<No Name>";
        }
    }
