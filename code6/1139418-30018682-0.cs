    public class SomeType
    {
        public int SomeField { get; set; }
    }
    class Program
    {
        static void GetData<T>()
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).ToList();
            var firstPropertyName = properties[0].Name;
            Console.WriteLine(firstPropertyName);
        }
        static void Main()
        {
            GetData<SomeType>();
        }
    }
