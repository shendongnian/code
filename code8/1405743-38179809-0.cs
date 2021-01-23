    class MyClass1
    {
        public MyClass1()
        {
            Prop = new MyClass2();
        }
        public MyClass2 Prop { get; set; } 
    }
    class MyClass2
    {
        private int Test()
        {
            return 5;
        }
    }
    static void Main(string[] args)
    {
        var obj = new MyClass1();
        var obj2 = obj.Prop;
        var propInfo = obj.GetType().GetProperty("Prop");
        var obj2Reflection = propInfo.GetValue(obj, null);
        var dynMethod = obj2.GetType().GetMethod("Test", BindingFlags.NonPublic | BindingFlags.Instance);
        var obj2Return = dynMethod.Invoke(obj2, null);
    }
