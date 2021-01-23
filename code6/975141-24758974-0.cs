    public class Base
    {
        protected int baseVal;
        // code ommitted
    }
    public class A : Base
    {
        int aVal;
        public A()
        {
            // calculate the value that you need
            baseVal = //some value that you calculate
        }
    }
