    class MyClass
    {
        public string Prop1 { get; private set; }
        public int Prop2 { get; private set; }
        public double Prop3 { get; private set; }
        public Dictionary<string, Action<object>> Updater { get; private set; }
        public MyClass()
        {
            Updater = new Dictionary<string, Action<object>>()
            {
                {"Prop1", o => Prop1 = o as string},
                {"Prop2", o => Prop2 = (int)o},
                {"Prop3", o => Prop3 = (double)o},
            };
        }
    }
    class Class27
    {
        static void Main()
        {
            Dictionary<string, MyClass> instances = new Dictionary<string, MyClass>();
            instances.Add("First", new MyClass());
            instances["First"].Updater["Prop1"]("hello");
            instances["First"].Updater["Prop2"](10);
            Console.WriteLine(instances["First"].Prop1);
            Console.WriteLine(instances["First"].Prop2);
        }
    }
