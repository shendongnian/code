    public class CodesIncremental
    {
        private object m_threadLock = new object();
        public static bool GetNewCodes()
        {
            lock(m_threadLock)
            {
            [ ... ]
            }
        }
    }
