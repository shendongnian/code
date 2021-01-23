    public class Reason
    {
        public Reason()
        {}
        public Reason(string name, int value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public int Value { get; set; }
        public override string ToString()
        {
            return string.Format("Hi, I am {0} and I contain [Name:{1}, Value:{2}]", GetType(), Name, Value);
        }
    }
