    public class CodesIncremental
    {
        private object m_threadLock = new object();
        private bool m_running = false;
    
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
            [ ... ]
            lock(m_threadLock)
            {
                m_running  = false;
            }
        }
    }
