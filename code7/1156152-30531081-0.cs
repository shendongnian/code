    public class Test : ITest
    {
        public int MyProperty
        {
            get;
            private set;
        }
        public void changeValue(int value)
        {
            MyProperty = value;
        }
    }
