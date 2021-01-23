    public static class Program
    {
        //private static readonly object SyncRoot = new object();
        //private static IEnumerable<int> EnumerableWithLock()
        //{
        //    lock (SyncRoot)
        //    {
        //        foreach (var i in new int[1])
        //        {
        //            yield return i;
        //        }
        //    }
        //}
        public static void Main()
        {
            SomeClass sc = new SomeClass();
            foreach (var i in sc.EnumerableWithLock())
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
    public class SomeClass
    {
        private static readonly object SyncRoot = new object();
        int[] i = { 1, 2, 3, 4, 5 };
        List<int> retval = new List<int>();
        public IEnumerable<int> EnumerableWithLock()
        {
            lock (SyncRoot)
            {
                foreach (var number in i)
                {
                    retval.Add(number);
                }
                return retval;
            }
        }
    }
