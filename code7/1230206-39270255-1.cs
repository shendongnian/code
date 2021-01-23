    public class DoubleKeyedDictionary<TKey1, TKey2, TValue>
    {
        class SItem
        {
            public TKey1 key1;
            public TKey2 key2;
            public TValue value;
        }
        Dictionary<TKey1, SItem> dic1;
        Dictionary<TKey2, SItem> dic2;
    }
