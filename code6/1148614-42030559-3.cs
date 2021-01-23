    public class MyType<T>
    {
        public T Value { get; set; }
        public MyType() : this(default(T))
        {}
        public MyType(T val)
        {
            Value = val;
        }
        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
    static void Main(string[] args)
    {
        var x = new MyType<int>(1);
        Foo(x);
        Console.WriteLine(x);//Writes 4
    }
    private static void Foo(MyType<int> y)
    {
        y.Value += 1;
        var l = new List<MyType<int>>();
        l.Add(y);
        l[0].Value += 1;//This does affect the value of x devlared in Main
        Console.WriteLine(l[0]);//Writes 3
        Console.WriteLine(y);//writes 3
        Foo2(l);
    }
    private static void Foo2(List<MyType<int>> l)
    {
        l[0].Value += 1;
        Console.WriteLine(l[0]);//writes 4
    }
