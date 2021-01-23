    public class Test : baseclass
    {
        public int Age { get; set; }
    }
        
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test();
            test.changeProperties("Age", 2);
        }
    }
