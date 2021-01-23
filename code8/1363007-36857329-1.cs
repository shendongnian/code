    public class Person
    {
        public Person()
        {
            // set default value
            Temperament = "hot";
            Job = "office slave";
        }
        public string Name { get; set; }
        public DateTime DoB { get; set; }
        public string Nationality { get; set; }
        public string Temperament { get; set; }
        public string Job { get; set; }
    }
