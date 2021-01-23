    public class HASPCLass
    {
        private static SerialPort m_port;
        private static bool m_initialized;
        private static int m_baudRate;
        static readonly object _syncObject = new object();
        private static HASPCLass _instance;
 
        public static HASPCLass Instance
        {
            get 
            {
                if(_instance == null)
                {
                    lock(_syncObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new HASPCLass();
                        }
                    }
                }
                return _instance;
            }
        }
        public void DoInitialization(int baudRate /*also could be other params*/)
        {
            if (!m_initialized)
            {
                Initialize(baudRate);
            }
        }
        private void Initialize(int baudrate /*also could have other params*/)
        {
            m_port.Open();
            m_baudRate = baudrate;
            m_initialized = true;
        }
        private void Uninitialize()
        {
            m_port.Close();
            m_initialized = false;
        }
        public void Read(byte[] buff)
        {
            m_port.Read(buff, 0, buff.Length);
        }
        public void Write(byte[] buff)
        {
            m_port.Write(buff, 0, buff.Length);
        }
        public void Close()
        {
            if (m_initialized)
            {
                Uninitialize();
            }
        }
    }
    
