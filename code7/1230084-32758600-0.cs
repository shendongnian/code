    internal class Program {
        private static void Main() {
            // don't run timer too often, you just need to detect 10-minutes idle, so running every 5 minutes or so is ok
            var timer = new Timer(_ => {
                var last = new LASTINPUTINFO();
                last.cbSize = (uint)LASTINPUTINFO.SizeOf;
                last.dwTime = 0u;
                if (GetLastInputInfo(ref last)) {
                    var idleTime = TimeSpan.FromMilliseconds(Environment.TickCount - last.dwTime);
                    // Console.WriteLine("Idle time is: {0}", idleTime);
                    if (idleTime > TimeSpan.FromMinutes(10)) {
                        // shutdown here
                    }
                }
            }, null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
            Console.ReadKey();
            timer.Dispose();            
        }
        [DllImport("user32.dll")]
        public static extern bool GetLastInputInfo(ref LASTINPUTINFO info);
        [StructLayout(LayoutKind.Sequential)]
        public struct LASTINPUTINFO {
            public static readonly int SizeOf = Marshal.SizeOf(typeof (LASTINPUTINFO));
            [MarshalAs(UnmanagedType.U4)] public UInt32 cbSize;
            [MarshalAs(UnmanagedType.U4)] public UInt32 dwTime;
        }
    }
