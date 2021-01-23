    class ABC
    {
        readonly int m_id;
        readonly string m_name;
        readonly int m_value;
        public ABC(int id, string name, int value)
        {
            this.m_id = id;
            this.m_name = name;
            this.m_value = value;
        }
        public int id { get { return m_id; } }
        public string name { get { return m_name; } }
        public int value { get { return m_value; } }
    }
