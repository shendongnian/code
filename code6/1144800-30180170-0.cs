        static class Program
        {
            private static DateTime? _loginTime;
            private static readonly object PadLock = new object();
    
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
    
            public static void SetLoginTime()
            {
                if (_loginTime != null) return;
    
                lock (PadLock)
                {
                    if (_loginTime != null) return;
                    _loginTime = DateTime.UtcNow;       //Only set this when _loginTime is still null after locking
                }
            }
    
            public static DateTime? GetLoginTime()
            {
                return _loginTime;
            }
        }
