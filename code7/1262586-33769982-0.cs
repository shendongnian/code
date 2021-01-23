    public class Derived : Test
    {
        public Derived()
        {
            _test = 5;
        }
    }
    public class Test
    {
        public int _test;
        public int GetTest()
        {
             return _test;
        }
    }
    var obj = new Derived();
    var test = obj.GetTest(); // returns 5
