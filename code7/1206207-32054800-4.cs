    public static class Tracker
    {
        /// <summary>
        /// Reference to the GetLastInputInfo in the user32.dll file.
        /// </summary>
        /// <param name="plii">LASTINPUTINFO struct</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        /// <summary>
        /// Polls the system for the milliseconds elapsed since last user input.
        /// </summary>
        /// <returns>Milliseconds since last user input.</returns>
        public static uint GetIdleTime()
        {
            LASTINPUTINFO lastInput = new LASTINPUTINFO();
            lastInput.cbSize = (uint)Marshal.SizeOf(lastInput);
            GetLastInputInfo(ref lastInput);
            return ((uint)Environment.TickCount - lastInput.dwTime);
        }
    }
    /// <summary>
    /// Struct required and populated by the user32.dll GetLastInputInfo method.
    /// </summary>
    internal struct LASTINPUTINFO
    {
        public uint cbSize; //Size of the struct.
        public uint dwTime; //TickCount at last input.
    }
