        public const int WTS_CURRENT_SESSION = -1;
        [StructLayout(LayoutKind.Sequential)]
        public struct WTS_SESSION_INFO
        {
            public Int32 SessionID;
            public IntPtr pWinStationName;
            public WTS_CONNECTSTATE_CLASS State;
        }
        [DllImport("wtsapi32.dll")]
        public static extern bool WTSEnumerateSessions(
            IntPtr hServer,
            Int32 Reserved,
            Int32 Version,
            ref IntPtr ppSessionInfo,
            ref Int32 pCount);
        [DllImport("wtsapi32.dll")]
        public static extern void WTSFreeMemory(IntPtr pMemory);
            IntPtr pSessions = IntPtr.Zero;
            int count = 0;
            if (WTSEnumerateSessions(WTS_CURRENT_SERVER_HANDLE, 0, 1, ref pSessions, ref count))
            {
                unsafe
                {
                    WTS_SESSION_INFO* pHead = (WTS_SESSION_INFO*)pSessions.ToPointer();
                    for (int i = 0; i < count; ++i)
                    {
                        WTS_SESSION_INFO* pCurrent = (pHead + i);
                        var session = new Session(pCurrent->SessionID, pCurrent->State);
                        _activeSessions[pCurrent->SessionID] = session;
                            session.Id, session.IsConnected, session.IsLoggedOn, session.User.UserName);
                    }
                }
                WTSFreeMemory(pSessions);
            }
