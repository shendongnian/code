    public class MyClass1
    {
        private double _privateNum = 9499488.07;
        public MyClass1(out Func<double> callback)
        {
            callback = () => _privateNum;
        }
        // ...        
    }
