    public class Simple
    {
        public List<Number> _numbers = new List<Number>();
        public List<Number> Numbers { get { return _numbers; } }
        public Simple()
        {
            _numbers.Add(new Number(5));
            _numbers.Add(new Number(6));
        }
    }
    public class Number
    {
        public int NMB { get; set; }
        public Number(int x) { NMB = x; }
    }
