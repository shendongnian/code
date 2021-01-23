    public class TwoKeyDictionary<Tkey1, Tkey2, TValue>
    {
        private object m_data_lock = new object();
        private Dictionary<Tkey1, Tkey2> m_dic1 = new Dictionary<Tkey1, Tkey2>();
        private Dictionary<Tkey2, TValue> m_dic2 = new private Dictionary<Tkey2, TValue>();
        
        public void AddValue(Tkey1 key1, Tkey2 key2, TValue value)
        {
            lock(m_data_lock)
            {
                m_dic1[key1] = key2;
                m_dic2[key2] = value;
            }
        }
        
        public TValue getByKey1(Tkey1 key1)
        {
            lock(m_data_lock)
                return m_dic2[m_dic1[key1]];
        }
        
        public TValue getByKey2(Tkey key2)
        {
            lock(m_data_lock)
                return m_dic2[key2];
        }
        
        public void removeByKey1(Tkey1 key1)
        {
            lock(m_data_lock)
            {
                Tkey2 tmp_key2 =   m_dic1[key1];
                m_dic1.Remove(key1);
                m_dic2.Remove(tmp_key2);
            }
        }
        
        public void removeByKey2(Tkey2 key2)
        {
            lock(m_data_lock)
            {
                Tkey1 tmp_key1 = m_dic1.First((kvp) => kvp.Value.Equals(key2)).Key;
                m_dic1.Remove(tmp_key1);
                m_dic2.Remove(key2);
            }
        }
    }
