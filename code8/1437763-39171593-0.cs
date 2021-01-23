    class Program
    {
        static void Main(string[] args)
        {
            int[] x = { 1, 2, 3 };
            Foo[] y = new Foo[]{ new Foo{Name="a"},new Foo{Name="b"},new Foo{Name="c"}};
            int i = 0;
            y.ToList().ForEach(a => a.Value = x[i++]);
            foreach (Foo f in y) 
              Console.Out.WriteLine(f.ToString());
        }
    }
    class Foo
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name + Value;
        }
    }
