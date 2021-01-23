    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Text { get { return ToString(); } }
        public override string ToString()
        {
            return String.Format("{0}, {1} years", Name, Age);
        }
    }
