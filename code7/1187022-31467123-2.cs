    public delegate string MyDelegate(int a, int b);
    public class MyClass
    {
        public MyDelegate restrictedMethod = _restrictedMethod;
        private string _restrictedMethod(int a, int b)
        {
            return (a + b).ToString();
        }
    }
    
    public class Test
    {
        public void It(MyClass mc)
        {
            // You can call method and get result
            string sumAsStr = mc.restrictedMethod(3, 5);
        }
    }
