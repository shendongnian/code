    public static class Program
    {
        public class A
        {
            private int _PropertyOne;
            private int _PropertyTwo;
            private int _PropertyThree;
            public int PropertyOne
            {
                get { return _PropertyOne; }
                set
                {
                    if (value == _PropertyOne)
                        return;
                    Log.Add(string.Format("PropertyOne changing value from {0} to {1}", _PropertyOne, value));
                    _PropertyOne = value;
                }
            }
            public int PropertyTwo
            {
                get { return _PropertyTwo; }
                set
                {
                    if (value == _PropertyTwo)
                        return;
                    Log.Add(string.Format("PropertyOne changing value from {0} to {1}", _PropertyTwo, value));
                    _PropertyTwo = value;
                }
            }
            public int PropertyThree
            {
                get { return _PropertyThree; }
                set
                {
                    if (value == _PropertyThree)
                        return;
                    Log.Add(string.Format("PropertyOne changing value from {0} to {1}", _PropertyThree, value));
                    _PropertyThree = value;
                }
            }
            public List<string> Log { get; private set; }
            public A()
            {
                Log = new List<string>();
            }
        }
        public class B
        {
            public int PropertyOne { get; set; }
            public int PropertyTwo { get; set; }
        }
        public static void Main(string[] args)
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<A, B>().ReverseMap();
            });
            var b = new B() {PropertyOne = 1, PropertyTwo = 2};
            var a = AutoMapper.Mapper.Map<B, A>(b);
            a.Log.ForEach(s => Console.WriteLine(s));
        }
    }
