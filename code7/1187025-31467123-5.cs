    public delegate string MyDelegate(int a, int b);
    public class MyClass
    {
        // Also you should make it readonly or getter-only property if you don't want outside changes
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
