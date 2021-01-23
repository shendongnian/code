    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class DummyReader : IDisposable
    {
        private readonly int limit;
        private int count = -1;
        public int Count { get { return count; } }
    
        public DummyReader(int limit)
        {
            this.limit = limit;
        }
        
        public bool Read()
        {
            count++;
            return count < limit;
        }
        
        public void Dispose()
        {
            Console.WriteLine("DummyReader.Dispose()");
        }
    }
    
    class Test
    {    
        static IEnumerable<int> FindValues(int valuesInReader)
        {
            Console.WriteLine("Take from the pool");
            
            using (var reader = new DummyReader(valuesInReader))
            {
                while (reader.Read())
                {
                    yield return reader.Count;
                }
            }
            Console.WriteLine("Put back in the pool");
        }
        
        static void Main()
        {
            var data = FindValues(2).Take(2).ToArray();
            Console.WriteLine(string.Join(",", data));
        }
    }
