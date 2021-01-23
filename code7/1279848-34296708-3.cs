    public class Students
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return string.Format("{0} -- {1} -- {2}", Name, Surname, Age);
        }
    }
