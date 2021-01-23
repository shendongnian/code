    namespace Test
    {
        public class ExistsClass
        {
            public bool Result { get; set; } = true;
            
            public int GetTotalCount() 
            {
                return Result ? 1 : 0;
            }
        }
        public class MyClass
        {
            public ExistsClass Exists { get; set; } = new ExistsClass();
        }
    
        static class Program
        {
            static void Main()
            {
                MyClass myclass = new MyClass();
                Console.WriteLine(myclass.Exists.GetTotalCount()); 
            }
        }
    }
