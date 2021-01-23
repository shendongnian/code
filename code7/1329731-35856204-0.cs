    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var l = GetList<Career>();
            }
    
            public static List<T> GetList<T>() where T : BaseClass
            {
                return new List<T>();
            }
        }
    
        public class BaseClass
        {
            public string Name { get; set; }
        }
    
        public class Career : BaseClass {}
    
        public class Artist : BaseClass {}
    }
