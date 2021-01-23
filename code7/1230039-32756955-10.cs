    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        public class ReadOnlyListSlice<T> : IReadOnlyList<T>
        {
            private readonly IReadOnlyList<T> _list;
            private readonly int _start;
            private readonly int _exclusiveEnd;
            public ReadOnlyListSlice(IReadOnlyList<T> list, int start, int exclusiveEnd)
            {
                _list = list;
                _start = start;
                _exclusiveEnd = exclusiveEnd;
            }
            public IEnumerator<T> GetEnumerator()
            {
                for (int i = _start; i <= _exclusiveEnd; ++i)
                    yield return _list[i];
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public int Count
            {
                get { return _exclusiveEnd - _start; }
            }
            public T this[int index]
            {
                get { return _list[index + _start]; }
            }
        }
        public class ListSlice<T> : IReadOnlyList<T>
        {
            private readonly IList<T> _list;
            private readonly int _start;
            private readonly int _exclusiveEnd;
            public ListSlice(IList<T> list, int start, int exclusiveEnd)
            {
                _list = list;
                _start = start;
                _exclusiveEnd = exclusiveEnd;
            }
            public IEnumerator<T> GetEnumerator()
            {
                for (int i = _start; i <= _exclusiveEnd; ++i)
                    yield return _list[i];
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public int Count
            {
                get { return _exclusiveEnd - _start; }
            }
            public T this[int index]
            {
                get { return _list[index+_start]; }
                set { _list[index+_start] = value; }
            }
        }
        internal class Program
        {
            private static void Main()
            {
                var ints = Enumerable.Range(1, 10).ToList();
                Console.WriteLine("Readonly Demo\n");
                demoReadOnlySlice(ints);
                Console.WriteLine("\nWriteable Demo\n");
                demoWriteableSlice(ints);
            }
            private static void demoReadOnlySlice(List<int> ints)
            {
                var test = new ReadOnlyListSlice<int>(ints, 4, 7);
                foreach (var i in test)
                    Console.WriteLine(i); // 5, 6, 7, 8
                Console.WriteLine();
                for (int i = 1; i < 4; ++i)
                    Console.WriteLine(test[i]); // 6, 7, 8
            }
            private static void demoWriteableSlice(List<int> ints)
            {
                var test = new ListSlice<int>(ints, 4, 7);
                foreach (var i in test)
                    Console.WriteLine(i); // 5, 6, 7, 8
                Console.WriteLine();
                test[2] = -1;
                for (int i = 1; i < 4; ++i)
                    Console.WriteLine(test[i]); // 6, -1, 8
            }
        }
    }
