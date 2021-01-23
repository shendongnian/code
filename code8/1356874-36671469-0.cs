    public interface IData 
    {
        int Number { get; set; }
    }
    public class Data : IData
    {
        public int Number { get; set; }
    }
    public class Test
    {
        public Data data { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Test();
            x.data = new Data();
            var type = x.data.GetType();
            var interfaces = type.GetInterfaces();
            Console.WriteLine(interfaces[0].Name == "IData"); // True
            Console.ReadKey();
        }
    }
