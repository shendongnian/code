    public class Person
    {
        public string Gender { get; set; }
        public int Age { get; set; }
        public float Income { get; set; }
        public override string ToString()
        {
            return Gender + "," + Age + "," + Income;
        }
    }
