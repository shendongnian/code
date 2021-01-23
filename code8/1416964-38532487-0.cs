    public static class ExtensionMethods
    {
        public static IEnumerable Take(this IEnumerable @this, int take)
        {
            
            var enumerator = @this.GetEnumerator();
            for (int i = 0; i < take && enumerator.MoveNext(); i++)
            {
                yield return enumerator.Current;
            }
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            System.Collections.ICollection collection = new[] { 8, 9, 10, 12 };
            var result = collection.Take(2);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
