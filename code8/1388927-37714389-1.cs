        public static string GetDisplayName(EventLogSession session, string logName)
        {
            var sb = new StringBuilder(512);
            int bufferUsed = 0;
            if (EvtIntGetClassicLogDisplayName(GetSessionHandle(session).DangerousGetHandle(), logName, 0, 0, sb.Capacity, sb, out bufferUsed))
                return sb.ToString();
            return logName;
        }
        private static SafeHandle GetSessionHandle(EventLogSession session)
        {
            return (SafeHandle)session.GetType().GetProperty("Handle", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(session);
        }
        [DllImport("wevtapi.dll", CharSet = CharSet.Unicode)]
        private static extern bool EvtIntGetClassicLogDisplayName(IntPtr session, [MarshalAs(UnmanagedType.LPWStr)] string logName, int locale, int flags, int bufferSize, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder displayName, out int bufferUsed);
