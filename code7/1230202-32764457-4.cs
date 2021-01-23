    public class TwoKeysDictionary<K1, K2, V>
    {
        private class TwoKeysValue<K1, K2, V>
        {
            public K1 Key1 { get; set; }
            public K2 Key2 { get; set; }
            public V Value { get; set; }
        }
        private List<TwoKeysValue<K1, K2, V>> m_list = new List<TwoKeysValue<K1, K2, V>>();
        public void Add(K1 key1, K2 key2, V value)
        {
            lock (m_list)
                m_list.Add(new TwoKeysValue<K1, K2, V>() { Key1 = key1, Key2 = key2, Value = value });
        }
        public V getByKey1(K1 key1)
        {
            lock (m_list)
                return m_list.First((tkv) => tkv.Key1.Equals(key1)).Value;
        }
        public V getByKey2(K2 key2)
        {
            lock (m_list)
                return m_list.First((tkv) => tkv.Key2.Equals(key2)).Value;
        }
        public void removeByKey1(K1 key1)
        {
            lock (m_list)
                m_list.Remove(m_list.First((tkv) => tkv.Key1.Equals(key1)));
        }
        public void removeByKey2(K2 key2)
        {
            lock (m_list)
                m_list.Remove(m_list.First((tkv) => tkv.Key2.Equals(key2)));
        }
    }
