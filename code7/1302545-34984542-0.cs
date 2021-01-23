    public class nulltest
    {
        public void test()
        {
            var instance = new testclass();
            var x = instance?.prop1;
            var y = instance?.prop2;
        }
    }
    public class testclass
    {
        public int prop1;
        public int prop2;
    }
