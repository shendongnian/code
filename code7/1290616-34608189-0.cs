    public class oBase
    {
        private Int32 m_i = 0;
        private String m_s = "";
        public Int32 MI { get { return m_i; } set { m_i = value; } }
        public String MS { get { return m_s; } set { m_s = value; } }
        public oBase() { }
        public oBase(int i)
        {
            // populate base class members using instance of data access class
        }
    }
