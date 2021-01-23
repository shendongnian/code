        public static IEnumerable<int> GetValues()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("yielding " + i);
                yield return i;
            }
        }
        class LazyList<T>
        {
            IEnumerator<T> enumerator;
            IList<T> list;
            public LazyList(IEnumerable<T> enumerable)
            {
                enumerator = enumerable.GetEnumerator();
                list = new List<T>();
            }
            public T this[int index]
            {
                get
                {
                    while (list.Count <= index && enumerator.MoveNext())
                    {
                        list.Add(enumerator.Current);
                    }
                    return list[index];
                }
            }
        }
        static void Main(string[] args)
        {
            var lazy = new LazyList<int>(GetValues());
            Console.WriteLine(lazy[0]);
            Console.WriteLine(lazy[4]);
            Console.WriteLine(lazy[2]);
            Console.WriteLine(lazy[1]);
            Console.WriteLine(lazy[7]);
            Console.WriteLine(lazy[9]);
            Console.WriteLine(lazy[6]);
            Console.Read();
        }
