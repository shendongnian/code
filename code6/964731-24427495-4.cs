    public class CodesIncremental
    {
        private static bool m_running = false;
    
        public static bool GetNewCodes()
        {
            if(m_running)
            {
                return;
            }
            m_running  = true;
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
