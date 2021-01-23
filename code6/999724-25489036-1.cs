    public class Person
    {
        public string Name { get; set; }
        public List<diseases> Diseases { get; set; }
        public Person(string name)
        {
            this.Name = name;
            Diseases = new List<diseases>();
        }
    }
