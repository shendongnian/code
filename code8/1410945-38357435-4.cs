    class Example
    {
        static void Main(string[] args)
        {
            "YourFile.txt".ReadAsLines()
                          .AsPaged(10)
                          .Select(a=>a.ToArray()) //required or else you will get random data since "WrappedEnumerator" is not thread safe
                          .AsParallel()
                          .WithDegreeOfParallelism(10)
                          .ForAll(a =>
            {
                //Do your work here.
                Console.WriteLine(a.Aggregate(new StringBuilder(), 
                                              (sb, v) => sb.AppendFormat("{0:000000} ", v), 
                                              sb => sb.ToString()));
            });
        }
    }
    public static class ToolsEx
    {
        public static IEnumerable<IEnumerable<T>> AsPaged<T>(this IEnumerable<T> items,
                                                                  int pageLength = 10)
        {
            using (var enumerator = new WrappedEnumerator<T>(items.GetEnumerator()))
                while (!enumerator.IsDone)
                    yield return enumerator.GetNextPage(pageLength);
        }
        public static IEnumerable<T> GetNextPage<T>(this IEnumerator<T> enumerator,
                                                         int pageLength = 10)
        {
            for (var i = 0; i < pageLength && enumerator.MoveNext(); i++)
                yield return enumerator.Current;
        }
        public static IEnumerable<string> ReadAsLines(this string fileName)
        {
            using (var reader = new StreamReader(fileName))
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
        }
    }
    internal class WrappedEnumerator<T> : IEnumerator<T>
    {
        public WrappedEnumerator(IEnumerator<T> enumerator)
        {
            this.InnerEnumerator = enumerator;
            this.IsDone = false;
        }
        public IEnumerator<T> InnerEnumerator { get; private set; }
        public bool IsDone { get; private set; }
        public T Current { get { return this.InnerEnumerator.Current; } }
        object System.Collections.IEnumerator.Current { get { return this.Current; } }
        public void Dispose()
        {
            this.InnerEnumerator.Dispose();
            this.IsDone = true;
        }
        public bool MoveNext()
        {
            var next = this.InnerEnumerator.MoveNext();
            this.IsDone = !next;
            return next;
        }
        public void Reset()
        {
            this.IsDone = false;
            this.InnerEnumerator.Reset();
        }
    }
