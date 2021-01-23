    public class MyBase
    {
        
        public MyBase(string param1, string param2, string param3)
        {
        }
    }
    public class MyClass: MyBase
    {
        // notice - hide constructor - private
        private MyClass(string p1, string p2, string p3) : base(p1, p2, p3)
        {
        }
     
        public static MyClass Create()
        {
            return new MyClass(null, null, null);
        }
    }
