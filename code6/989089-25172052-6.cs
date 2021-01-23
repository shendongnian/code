    public struct Test 
    {
        readonly string m_str;
        readonly int m_int1;
        public string str { get { return m_str; } }
        public int int1 { get { return m_int1; } }
        public Test(string str, int int1)
        {
            m_str = str;
            m_int1 = int1;
        }
    }
 
