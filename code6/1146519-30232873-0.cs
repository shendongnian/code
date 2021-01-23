    public class Person
    {
        public string firstName { get; set; };
        public string lastName { get; set; };
        public int height { get; set; };
        public double weight { get; set; };
    
        public Person() { }
        public Person(string firstName, string lastName, int height, double weight)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.height = height;
            this.weight = weight;
        }
    }
