    class Program
        {
            static void Main(string[] args)
            {
                Foo<int, string> foo = new Foo<int, string>();
                foo.dict.Add(1, "a");
                foo.dict.Add(2, "b");
                Console.WriteLine(foo[1]);
                foo[3] = "c";
                Console.WriteLine(foo[3]);
                Console.ReadLine();
            }
        }
    
        public interface IIndexGettable<TKey, TValue>
        {
            TValue this[TKey key] { get; }
        }
    
        public interface IIndexSettable<TKey, TValue>
        {
            TValue this[TKey key] { set; }
        }
    
        public interface IIndexable<TKey, TValue> : IIndexGettable<TKey, TValue>, IIndexSettable<TKey, TValue>
        {
    
        }
    
        public class Foo<TKey, TValue> : IIndexable<TKey, TValue>
        {
            public Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();
            public TValue this[TKey key]
            {
                get
                {
                    return dict[key];
                }
    
                set
                {
                    dict[key] = value;
                }
            }
    
        }
