    /// <summary>
    /// A timer that raises the <see cref="Idle"/> event when it detects the session 
    /// </summary>
    public sealed class SystemIdleTimer : IDisposable
    {
        private readonly System.Threading.Timer _timer;
        private readonly SynchronizationContext _synchronizationContext;
        /// <summary>
        /// This event is rasied when the sysstem's idle time is greater than <see cref="MaxIdleTime"/>.
        /// This event is posted to the SynchronizationContext that the constructor was run under.
        /// </summary>
        public event EventHandler Idle;
        /// <summary>
        /// The amount of idle time that must pass before the <see cref="Idle"/> event is raised.
        /// </summary>
        public TimeSpan MaxIdleTime { get; set; }
        /// <summary>
        /// Is the user currently detected as idle;
        /// </summary>
        public bool IsDetectedIdle { get; private set; }
        /// <summary>
        /// Creates a new timer with a specified trigger level and a check frequency of once a minute.
        /// </summary>
        /// <param name="maxIdleTime">The amount of idle time that must pass before the <see cref="Idle"/> event is raised.</param>
        public SystemIdleTimer(TimeSpan maxIdleTime)
            : this(maxIdleTime, TimeSpan.FromMinutes(1))
        {
        }
        /// <summary>
        /// Creates a new timer with a specified trigger level and a check frequency.
        /// </summary>
        /// <param name="maxIdleTime">The amount of idle time that must pass before the <see cref="Idle"/> event is raised.</param>
        /// <param name="checkInterval">The frequency in miliseconds to check the idle timer.</param>
        public SystemIdleTimer(TimeSpan maxIdleTime, TimeSpan checkInterval)
        {
            MaxIdleTime = maxIdleTime;
            _synchronizationContext = SynchronizationContext.Current;
            _timer = new System.Threading.Timer(TimerCallback, null, checkInterval, checkInterval);
        }
        public void Dispose()
        {
            _timer.Dispose();
            Idle = null;
        }
        private void TimerCallback(object state)
        {
            var idleTime = GetIdleTime();
            if (idleTime > MaxIdleTime)
            {
                if (!IsDetectedIdle)
                {
                    IsDetectedIdle = true;
                    OnIdle();
                }
            }
            else
            {
                IsDetectedIdle = false;
            }
        }
        private void OnIdle()
        {
            var idle = Idle;
            if (idle != null)
            {
                if (_synchronizationContext != null)
                {
                    _synchronizationContext.Post(state => idle(this, EventArgs.Empty), null);
                }
                else
                {
                    idle(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Returns the amout of time the system has been idle.
        /// </summary>
        /// <returns>A TimeSpan representing the idle time for the session.</returns>
        public static TimeSpan GetIdleTime()
        {
            try
            {
                uint idleMiliseconds = 0;
                LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
                lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
                lastInputInfo.dwTime = 0;
                
                uint systemUpTime = GetTickCount();
                if (GetLastInputInfo(ref lastInputInfo))
                {
                    uint lastInputTime = lastInputInfo.dwTime;
                    if (lastInputTime > systemUpTime)
                    {
                        // The elapsed time is stored as a DWORD value. Therefore, the time will wrap around to zero if the system is run continuously for 49.7 days.
                        // so, we need a bit more math...
                        // how far between last input and the current time rolling over to 0
                        idleMiliseconds = (uint.MaxValue - lastInputTime);
                        // add that to the current ticks
                        idleMiliseconds = idleMiliseconds + systemUpTime;
                    }
                    else
                    {
                        idleMiliseconds = systemUpTime - lastInputTime;
                    }
                }
                
                return TimeSpan.FromMilliseconds(idleMiliseconds);
            }
            catch (Exception)
            {
                return TimeSpan.Zero;
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct LASTINPUTINFO
        {
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dwTime;
        }
        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        [DllImport("kernel32.dll")]
        static extern uint GetTickCount();
    }
