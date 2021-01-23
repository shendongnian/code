    class Program
    {
        static void Main(string[] args)
        {
            var properties = typeof(MyObject).GetProperties();
            var stringsInMyObject = properties.Where(x=> x.GetMethod.ReturnType == typeof(string));
        }
    }
    public class MyObject
    {
        public string SomeString { get; set; }
        public string SomeString2 { get; set; }
        public int SomeInt { get; set; }
        public int SomeInt2 { get; set; }
    }
