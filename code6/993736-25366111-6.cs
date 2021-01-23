    public class MyTestClass
    {
        public MyTestClass(int key1, string key2, decimal key3)
        {
            m_key1 = key1;
            m_key2 = key2;
            m_key3 = key3;
        }
        private int m_key1;
        public int Key1 { get { return m_key1; } }
        private string m_key2;
        public string Key2 { get { return m_key2; } }
        private decimal m_key3;
        public decimal Key3 { get { return m_key3; } }
    }
