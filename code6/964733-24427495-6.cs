    public class CodesIncremental
    {
        private static object m_threadLock = new object();
        private static bool m_running = false;
    
        public static bool GetNewCodes()
        {
            lock(m_threadLock)
            {
                if(m_running)
                {
                    return;
                }
                m_running  = true;
            }
            try
            {
                [ ... ]
            }
            finally
            {
                m_running  = false;
            }
        }
    }
