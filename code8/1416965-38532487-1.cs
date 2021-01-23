    public static class ExtensionMethods
    {
        public static IEnumerable Take(this IEnumerable @this, int take)
        {
            
            var enumerator = @this.GetEnumerator();
            try
            {
                for (int i = 0; i < take && enumerator.MoveNext(); i++)
                {
                    yield return enumerator.Current;
                }
            }
            finally
            {
                var disposable = enumerator as IDisposable;
                if(disposable != null)
                    disposable.Dispose();
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
