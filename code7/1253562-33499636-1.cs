    static void Main(string[] args)
    {
        Dictionary<MyKey, string> fooDictionary = new Dictionary<MyKey, string>();
        fooDictionary.Add(new MyKey() {FooNumber=1, Sequence=50 }, "1");
        fooDictionary.Add(new MyKey() { FooNumber = 2, Sequence = 40 }, "2");
        fooDictionary.Add(new MyKey() { FooNumber = 3, Sequence = 30 }, "3");
        fooDictionary.Add(new MyKey() { FooNumber = 4, Sequence = 20 }, "4");
        fooDictionary.Add(new MyKey() { FooNumber = 5, Sequence = 10 }, "5");
        var result = from c in fooDictionary orderby c.Key.Sequence select c;
        Console.WriteLine("");   
    }
    class MyKey
    {
        public int FooNumber { get; set; }
        public DateTime MyProperty { get; set; }
        public int Sequence { get; set; }
    }
