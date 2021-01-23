    using System;
    using System.Collections;
    using System.Collections.Generic;
    namespace Demo
    {
        public sealed class SequencedSet<T>: IEnumerable<T>
        {
            private readonly SortedDictionary<int, T> items = new SortedDictionary<int, T>();
            private readonly Dictionary<T, int> order = new Dictionary<T, int>();
            private int sequenceNumber = 0;
            public void Add(T item)
            {
                if (order.ContainsKey(item))
                    return; // Or throw if you want.
                order[item] = sequenceNumber;
                items[sequenceNumber] = item;
                ++sequenceNumber;
            }
            public void Remove(T item)
            {
                if (!order.ContainsKey(item))
                    return; // Or throw if you want.
                int sequence = order[item];
                items.Remove(sequence);
                order.Remove(item);
            }
            public IEnumerator<T> GetEnumerator()
            {
                return items.Values.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        internal class Program
        {
            private static void Main()
            {
                var test = new SequencedSet<string>();
                test.Add("One");
                test.Add("Two");
                test.Add("Three");
                test.Add("Four");
                test.Add("Five");
                test.Remove("Four");
                test.Remove("Two");
                foreach (var item in test)
                    Console.WriteLine(item);
            }
        }
    }
