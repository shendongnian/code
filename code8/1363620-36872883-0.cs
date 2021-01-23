    public class BaseClass
    {
        public BaseClass(int value)
        {
            MyField = value; // This doesn't point to SubClass.MyField
        }
        public int MyField;
    }
