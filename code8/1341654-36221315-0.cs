    public class MyClass
    {
        public static bool operator==(MyClass mc1, MyClass mc2)
        {
            return false;
        }
        public static bool operator!=(MyClass mc1, MyClass mc2)
        {
            return !(mc1 == mc2);
        }
    }
    MyClass mc1 = null;
    var xx = new
    {
        Old = mc1
    };
