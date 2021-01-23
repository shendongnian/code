    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazy =
            new Lazy<Singleton>(() => new Singleton());
        public static Singleton Instance { get { return lazy.Value; } }
        SerialPort commPort = new SerialPort();
        private readonly object _LEDLock = new object();
        private Singleton()
        {
            // Setup SerialPort
        }
        /// <summary>
        /// This goes in the singleton class, because this is the class actually doing the work.
        /// The behavior belongs in this class. Now it can be called with thread-safety from
        /// any number of threads
        /// </summary>
        public Boolean SetLEDStatus(int onOff)
        {
            lock(_LEDLock)
            {
                var cmd = "SET LED " + onOff.ToString() + "\r\n";
                commPort.WriteLine(cmd);
                string status = commPort.ReadLine();
                return (status.Contains("SUCCESS")) ? true : false;
            }
        }
        public Boolean IsLEDOn()
        {
            lock(_LEDLock)
            {
                commPort.Write("GET LED\r\n");
                var result = commPort.ReadLine().Contains("ON")) ? true : false;
                return result;
            }
        }
    } 
