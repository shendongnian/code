    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                DynamicArray<int> intArray = new DynamicArray<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
                foreach (var number in intArray)
                {
                    Console.WriteLine(number.ToString());
                }
                Console.WriteLine("The Second Element is: " + intArray[1].ToString());
                intArray[1] = 6;
                Console.WriteLine("Changed to 6: " + intArray[1].ToString());
                Console.WriteLine("Press any key...");
                Console.ReadKey(true);
            }
        }
        public class DynamicArray<T> : IEnumerable<T> where T: struct
        {
            private List<T> _items = new List<T>();
            public DynamicArray(params T[] items)
            {
                _items.AddRange(items);
            }
            public T this[int index]
            {
                get { return _items[index]; }
                set { _items[index] = value; }
            }
            public int Count { get { return _items.Count; } }
            public void AddNew(T item)
            {
                _items.Add(item);
            }
            public void RemoveAt(int index)
            {
                _items.RemoveAt(index);
            }
            public void Remove(T item)
            {
                _items.Remove(item);
            }
            public IEnumerator<T> GetEnumerator()
            {
                return _items.GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return _items.GetEnumerator();
            }
        }
    }
