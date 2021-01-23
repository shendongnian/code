    namespace WordDavService
    {
   
    [ServiceContract]
    public interface IWcfDocOpen
    {
        [WebGet(UriTemplate = "/run/{Path}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        string Run(string Path);
    }
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class DocOpenWcfService : IWcfDocOpen
    {
        //public static void Main() 
        public string Run(string _Path)
        {
            int session = WinAPI.WTSGetActiveConsoleSessionId();
            if (session ==0xFFFFFFFF)
            {
                return "NoActiveSession";
            }
            IntPtr userToken;
            bool res = WinAPI.WTSQueryUserToken(session, out userToken);
            string path =  "C:\\Windows\\LauncherWord.exe";
            string dir = Path.GetDirectoryName(path);
           WinAPI.STARTUPINFO si = new WinAPI.STARTUPINFO();
            si.lpDesktop = "winsta0\\default";
            si.cb = (uint)Marshal.SizeOf(si);
            WinAPI.PROCESS_INFORMATION pi = new WinAPI.PROCESS_INFORMATION();
            WinAPI.SECURITY_ATTRIBUTES sa = new WinAPI.SECURITY_ATTRIBUTES();
            sa.bInheritHandle = true;
            sa.length = Marshal.SizeOf(sa);
            sa.lpSecurityDescriptor = IntPtr.Zero;
            if (!WinAPI.CreateProcessAsUser(userToken,       // user token
                                            path+" "+_Path,           // exexutable path
                                            "",   // arguments
                                            ref sa,         // process security attributes ( none )
                                            ref sa,         // thread  security attributes ( none )
                                            true,          // inherit handles?
                                            0x02000000,              // creation flags
                                            IntPtr.Zero,    // environment variables
                                            dir,            // current directory of the new process
                                            ref si,         // startup info
                                            ref pi))        // receive process information in pi
            {
                int error = Marshal.GetLastWin32Error();
                return "Error CreateProcessAsUser:" + error + " File: " + path + " " + _Path;
            }
            else
                return "Success:" + path + " " + _Path;
        }
    }
    public static class WinAPI
    {
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern int WTSGetActiveConsoleSessionId();
       [DllImport("wtsapi32.dll", SetLastError = true)]
        public static extern bool WTSQueryUserToken(int Session,[Out] out IntPtr phToken);
        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public uint dwProcessId;
            public uint dwThreadId;
        }
        public struct STARTUPINFO
        {
            public uint cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public uint dwX;
            public uint dwY;
            public uint dwXSize;
            public uint dwYSize;
            public uint dwXCountChars;
            public uint dwYCountChars;
            public uint dwFillAttribute;
            public uint dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }
        public struct SECURITY_ATTRIBUTES
        {
            public int length;
            public IntPtr lpSecurityDescriptor;
            public bool bInheritHandle;
        }
              
      [DllImport("advapi32.dll", EntryPoint = "CreateProcessAsUser",      SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
    public static extern bool  CreateProcessAsUser(IntPtr hToken, string lpApplicationName, string lpCommandLine, 
                          ref SECURITY_ATTRIBUTES lpProcessAttributes, ref SECURITY_ATTRIBUTES lpThreadAttributes, 
                          bool bInheritHandle, Int32 dwCreationFlags, IntPtr lpEnvrionment,
                          string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, 
                          ref PROCESS_INFORMATION lpProcessInformation);
        }
    }
