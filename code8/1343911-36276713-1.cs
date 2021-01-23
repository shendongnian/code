    public interface IFirst
    {
        void Method1(string a);
    }
    public interface ISecond
    {
        double Method2(int b, bool a);
    }    
    public interface IComplex : IFirst, ISecond
    {
    }
    public class MyException : Exception
    {
        public MyException(string message) : base(message)
        {
        }
    }
    public class Sub1Client : IFirst
    {
        public void Method1(string a)
        {
            Console.WriteLine("IFirst.Method1");
            Console.WriteLine(a);
        }
    }
    public class Sub2Client : ISecond
    {
        public double Method2(int b, bool a)
        {
            Console.WriteLine("ISecond.Method2");
            return a ? b : -b;
        }
    }
    public class MainClient : IComplex
    {
        public MainClient()
        {
            Sub1 = new Sub1Client();
            Sub2 = new Sub2Client();
        }
        public static Sub1Client Sub1;
        public static Sub2Client Sub2;        
        private T FindAndInvoke<T>(string methodName, params object[] args)
        {
            foreach(var field in this.GetType().GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var method = field.FieldType.GetMethod(methodName);
                if(method != null)
                    return (T)method.Invoke(field.GetValue(this), args);
            }
            throw new MyException("Method was not found!");
        }
        public void Method1(string a)
        {            
            FindAndInvoke<object>(MethodBase.GetCurrentMethod().Name, a);            
        }
        public double Method2(int b, bool a)
        {
            return FindAndInvoke<double>(MethodBase.GetCurrentMethod().Name, b, a);
        }
    }    
    public static void Main()
    {
        var test = new MainClient();
        test.Method1("test");
        Console.WriteLine(test.Method2(2, true));
    }
