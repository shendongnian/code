    class Program
    {
        static void Main(string[] args)
        {
            dynamic ex = ExpandoFactory.Create("First", "Donald", "Last", "Duck");
            Console.WriteLine(ex.First);
            Console.WriteLine(ex.Last);
        }
    }
    
    static class ExpandoFactory
    {
        internal static ExpandoObject Create(params string[] items)
        {
            //safety checks omitted for brevity
            IDictionary<string, object> result = new ExpandoObject();
            for (int i = 0; i < items.Length; i+=2)
            {
                result[items[i]] = items[i + 1];
            }
            return result as ExpandoObject;
        }
    }
