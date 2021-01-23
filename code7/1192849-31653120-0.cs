    class Program
    {
        static void Main(string[] args)
        {
            dynamic d = 0;
    
            Test test = new Test();
            int x = test.TestDynamic(d);
            int y = test.TestInt(0);
        }
    }
    
    public class Test
    {
        public int TestDynamic(dynamic data)
        {
            return 0;
        }
    
        public int TestInt(int data)
        {
            return 0;
        }
    }
