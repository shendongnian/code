    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace WTSInfoExample
    {
    
        public enum WTS_INFO_CLASS:int
        {
            WTSInitialProgram = 0,
            WTSApplicationName = 1,
            WTSWorkingDirectory = 2,
            WTSOEMId = 3,
            WTSSessionId = 4,
            WTSUserName = 5,
            WTSWinStationName = 6,
            WTSDomainName = 7,
            WTSConnectState = 8,
            WTSClientBuildNumber = 9,
            WTSClientName = 10,
            WTSClientDirectory = 11,
            WTSClientProductId = 12,
            WTSClientHardwareId = 13,
            WTSClientAddress = 14,
            WTSClientDisplay = 15,
            WTSClientProtocolType = 16,
            WTSIdleTime = 17,
            WTSLogonTime = 18,
            WTSIncomingBytes = 19,
            WTSOutgoingBytes = 20,
            WTSIncomingFrames = 21,
            WTSOutgoingFrames = 22,
            WTSClientInfo = 23,
            WTSSessionInfo = 24,
            WTSSessionInfoEx = 25,
            WTSConfigInfo = 26,
            WTSValidationInfo = 27,
            WTSSessionAddressV4 = 28,
            WTSIsRemoteSession = 29
        }
    
    
        public enum WTS_CONNECTSTATE_CLASS:int
        {
            WTSActive,
            WTSConnected,
            WTSConnectQuery,
            WTSShadow,
            WTSDisconnected,
            WTSIdle,
            WTSListen,
            WTSReset,
            WTSDown,
            WTSInit,
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct WTSINFOA
        {
            public const int WINSTATIONNAME_LENGTH = 32;
            public const int DOMAIN_LENGTH = 17;
            public const int USERNAME_LENGTH = 20;
            public WTS_CONNECTSTATE_CLASS State;
            public int SessionId;
            public int IncomingBytes;
            public int OutgoingBytes;
            public int IncomingFrames;
            public int OutgoingFrames;
            public int IncomingCompressedBytes;
            public int OutgoingCompressedBytes;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = WINSTATIONNAME_LENGTH)]
            public byte[] WinStationNameRaw;
            public string WinStationName
            {
                get
                {
                    return Encoding.ASCII.GetString(WinStationNameRaw);
                }
            }
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = DOMAIN_LENGTH)]
            public byte[] DomainRaw;
            public string Domain
            {
                get
                {
                    return Encoding.ASCII.GetString(DomainRaw);
                }
            }
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = USERNAME_LENGTH + 1)]
            public byte[] UserNameRaw;
            public string UserName
            {
                get
                {
                    return Encoding.ASCII.GetString(UserNameRaw);
                }
            }
            public long ConnectTimeUTC;
            public DateTime ConnectTime
            {
                get
                {
                    return DateTime.FromFileTimeUtc(ConnectTimeUTC);
                }
            }
            public long DisconnectTimeUTC;
            public DateTime DisconnectTime
            {
                get
                {
                    return DateTime.FromFileTimeUtc(DisconnectTimeUTC);
                }
            }
            public long LastInputTimeUTC;
            public DateTime LastInputTime
            {
                get
                {
                    return DateTime.FromFileTimeUtc(LastInputTimeUTC);
                }
            }
            public long LogonTimeUTC;
            public DateTime LogonTime
            {
                get
                {
                    return DateTime.FromFileTimeUtc(LogonTimeUTC);
                }
            }
            public long CurrentTimeUTC;
            public DateTime CurrentTime
            {
                get
                {
                    return DateTime.FromFileTimeUtc(CurrentTimeUTC);
                }
            }
        }
        public class RDPInfo
        {
            [DllImport("wtsapi32.dll")]
            static extern IntPtr WTSOpenServer([MarshalAs(UnmanagedType.LPStr)] String pServerName);
    
            [DllImport("wtsapi32.dll")]
            static extern void WTSCloseServer(IntPtr hServer);
    
            [DllImport("wtsapi32.dll")]
            static extern Int32 WTSEnumerateSessions(
                IntPtr hServer,
                [MarshalAs(UnmanagedType.U4)] Int32 Reserved,
                [MarshalAs(UnmanagedType.U4)] Int32 Version,
                ref IntPtr ppSessionInfo,
                [MarshalAs(UnmanagedType.U4)] ref Int32 pCount);
    
            [DllImport("wtsapi32.dll")]
            static extern void WTSFreeMemory(IntPtr pMemory);
    
            [DllImport("Wtsapi32.dll")]
            static extern bool WTSQuerySessionInformation(System.IntPtr hServer, int sessionId, WTS_INFO_CLASS wtsInfoClass, out System.IntPtr ppBuffer, out uint pBytesReturned);
    
            [StructLayout(LayoutKind.Sequential)]
            private struct WTS_SESSION_INFO
            {
                public Int32 SessionID;
                [MarshalAs(UnmanagedType.LPStr)]
                public String pWinStationName;
                public WTS_CONNECTSTATE_CLASS State;
            }
    
            public static IntPtr OpenServer(String Name)
            {
                IntPtr server = WTSOpenServer(Name);
                return server;
            }
    
            public static void CloseServer(IntPtr ServerHandle)
            {
                WTSCloseServer(ServerHandle);
            }
    
            public static List<RDPSession> ListUsers(String ServerName)
            {
                List<RDPSession> List = new List<RDPSession>();
    
                IntPtr serverHandle = IntPtr.Zero;
                List<String> resultList = new List<string>();
                serverHandle = OpenServer(ServerName);
    
                IntPtr SessionInfoPtr = IntPtr.Zero;
                IntPtr clientNamePtr = IntPtr.Zero;
                IntPtr wtsinfoPtr = IntPtr.Zero;
                IntPtr clientDisplayPtr = IntPtr.Zero;
    
    
                try
                {
    
                    Int32 sessionCount = 0;
                    Int32 retVal = WTSEnumerateSessions(serverHandle, 0, 1, ref SessionInfoPtr, ref sessionCount);
                    Int32 dataSize = Marshal.SizeOf(typeof(WTS_SESSION_INFO));
                    Int32 currentSession = (int)SessionInfoPtr;
                    uint bytes = 0;
                    if (retVal != 0)
                    {
                        for (int i = 0; i < sessionCount; i++)
                        {
                            WTS_SESSION_INFO si = (WTS_SESSION_INFO)Marshal.PtrToStructure((System.IntPtr)currentSession, typeof(WTS_SESSION_INFO));
                            currentSession += dataSize;
                            
                            WTSQuerySessionInformation(serverHandle, si.SessionID, WTS_INFO_CLASS.WTSClientName, out clientNamePtr, out bytes);
                            WTSQuerySessionInformation(serverHandle, si.SessionID, WTS_INFO_CLASS.WTSSessionInfo, out wtsinfoPtr, out bytes);
    
                            var wtsinfo = (WTSINFOA)Marshal.PtrToStructure(wtsinfoPtr, typeof(WTSINFOA));
                            RDPSession temp = new RDPSession();
                            temp.Client = Marshal.PtrToStringAnsi(clientNamePtr);
                            temp.Server = ServerName;
                            temp.UserName = wtsinfo.UserName;
                            temp.Domain = wtsinfo.Domain;
                            temp.ConnectionState = si.State;
                            temp.SessionId = si.SessionID;
                            temp.sessionInfo = wtsinfo;
                            List.Add(temp);
    
                            WTSFreeMemory(clientNamePtr);
                            WTSFreeMemory(wtsinfoPtr);
                        }
                        WTSFreeMemory(SessionInfoPtr);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                finally
                {
                    CloseServer(serverHandle);
                }
    
                return List;
            }
        }
    
        public class RDPSession
        {
            public string UserName;
            public string Domain;
            public int SessionId;
            public string Client;
            public string Server;
            public WTS_CONNECTSTATE_CLASS ConnectionState;
            public WTSINFOA sessionInfo;
        }
        class Program
        {
            static void Main(string[] args)
            {
                List<RDPSession> ServerList = new List<RDPSession>();
                ServerList = RDPInfo.ListUsers("SERVERNAME");
                foreach (RDPSession item in ServerList)
                {
                    Console.WriteLine("{0,-15} {1,-15} {2,-35} {3,-40}", item.UserName, item.ConnectionState, item.Client, item.sessionInfo.LogonTime);
                }
            }
        }
    }
