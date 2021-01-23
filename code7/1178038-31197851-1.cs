    public static class FakeDatabase
    {
        public static Class2 c2instance1 = new Class2 { Prop4 = "Value4" };
        public static Class1 c1instance1 = new Class1
        {
            Prop1 = "value1",
            Prop2 = new Class2[] { c2instance1 },
            Prop3 = new string[] { "value3" }
        };
        public static Class1[] AllData = new Class1[] { c1instance1 };
    }
