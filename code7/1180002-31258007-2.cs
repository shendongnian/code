    class Program
    {
        static void Main(string[] args)
        {
            INumber t = new test();
    
            INumber t2 = new test2();
        }
    }
    
    public class test : INumber
    {
        public int Number { get; set; }
    }
    
    public class test2 : INumber
    {
        public int Number { get; set; }
    }
    
    public interface INumber
    {
        int Number { get; set; }
    }
