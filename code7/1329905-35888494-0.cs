    public class Employee
    {
        public string Name { get; set; }
        public DayOfWeek dayOff { get; set; }
        public override string ToString()
        {
            return "I'm " + Name + " and I don't work on " + dayOff;
        }
    }
