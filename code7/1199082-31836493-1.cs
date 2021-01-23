        static void Main(string[] args)
        {
            Console.WriteLine(DerivedClass.Instance.Method());
            Console.WriteLine(DerivedClass.TestMethod());
            Console.ReadKey();
        }
    }
    public abstract class BaseClass
    {
        public string Method()
        {
            return "yo";
        }
    }
    public sealed class DerivedClass : BaseClass
    {
        private static DerivedClass _instance;
        private DerivedClass()
            : base()
        {
        }
        public static DerivedClass Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DerivedClass();
                }
                return _instance;
            }
        }
        public static string TestMethod()
        {
            //here is working perfect!
            return DerivedClass.Instance.Method();
        }
    }
