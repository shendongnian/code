    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc;
            MyClass mc2;
            mc = (MyClass)MyClass.init();
            mc2 = (MyClass)MyClass.init();
            Console.WriteLine(mc.myString + " from instance " + mc.instanceID);
            Console.WriteLine(mc2.myString + " from instance " + mc2.instanceID);
            Console.ReadKey();
        }
    }
    public class MyClass
    {
        public int instanceID;
        internal static int instanceCount;
        internal static MyClass _instance = new MyClass();
        internal MyClass()
        {
            instanceCount++;
            instanceID = instanceCount;
        }
        public MyClass Instance
        {
            get
            {
                return _instance;
            }
        }
        public string myString = "Hello ";
        public static object init()
        {
            if (instanceCount > 0)
                return _instance;
            else
            {
                MyClass _instance = new MyClass();
                return _instance;
            }
        }
    }
