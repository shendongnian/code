    using System.Collections.Generic;
    
    namespace ConsoleApplication3
    {
        public class Metric : IAggregatable<Metric>
        {
            public int Total { get; set; }
    
            public Metric(int total)
            {
                Total = total;
            }
    
            public void Aggregate(Metric other)
            {
                Total += other.Total;
            }
        }
    
        public static class DictionaryExtensions
        {
            public static void Aggregate<TKey, TValue>(this Dictionary<TKey, TValue> dic, TKey key, TValue value) where TValue : IAggregatable<TValue>
            {
                TValue result;
                if (dic.TryGetValue(key, out result))
                    dic[key].Aggregate(value);
                else
                    dic[key] = value;
            }
        }
    
        public interface IAggregatable<T>
        {
            void Aggregate(T other);
        }
    
        class Program
        {
            void Main()
            {
                var foo = new Dictionary<string, Metric>();
                foo["first"] = new Metric(5);
                foo["sec"] = new Metric(10);
    
                foo.Aggregate("first", new Metric(5));
            }        
        }
    }
