    public class MyObject : IFormattable
    {
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "IFormattable";
        }
        public override string ToString()
        {
            return "ToString";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyObject();
            Console.WriteLine(obj);
            Console.WriteLine(obj.ToString());
            Console.ReadKey();
        }
    }
