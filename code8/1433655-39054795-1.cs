    namespace ReadProcessMemoryExample
    {
        using System;
        using System.Diagnostics;
        using System.Linq;
        using System.Runtime.InteropServices;
        using WinApi;
    
        public class Program
        {
            public static unsafe void Main(string[] args)
            {
                // Memory writer generate Guid and write it buffer
                // Memory reader read it 
                if (args != null && args.Contains("-writer"))
                {
                    MemoryWriter();
                    return;
                }
                else
                {
                    MemoryReader();
                }
            }
            private static void MemoryReader()
            {
                Console.WriteLine("Mode: Reader");
    
                if (!EnablePrivelege())
                {
                    Console.WriteLine("Couldn't enable privilegs. Exiting...");
                    return;
                }
                Console.Write("Enter generated Guid from writer for correctess checking: ");
                Guid validGuid = Guid.Parse(Console.ReadLine());
                Console.Write("Enter process id: ");
                int procId = int.Parse(Console.ReadLine());
                Console.Write("Enter memory reading addr in hex(example, 0x24B004446D0): ");
                string strHex = Console.ReadLine().Replace("0x", "");
                long addrToRead = long.Parse(strHex, System.Globalization.NumberStyles.HexNumber);
    
                IntPtr hProc = IntPtr.Zero, hToken = IntPtr.Zero;
                hProc = WinApiWrapper.OpenProcess(ProcessAccessFlags.All, false, procId);
                try
                {
                    if (!WinApiWrapper.OpenProcessToken(hProc, (uint)TokenAccess.TOKEN_ALL_ACCESS, out hToken))
                    {
                        Console.WriteLine("OpenProcessToken failed with error: {0}", Marshal.GetLastWin32Error());
                        return;
                    }
                    IntPtr pAddr = new IntPtr(addrToRead);
                    MEMORY_BASIC_INFORMATION memInfo;
                    if (0 == WinApiWrapper.VirtualQueryEx(hProc, pAddr, out memInfo, (uint)Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)))){
                        Console.WriteLine("VirtualQueryEx failed with error: {0}", Marshal.GetLastWin32Error());
                        return;
                    }
                    Console.WriteLine("Memory info: ");
                    PrintMemInfo(memInfo);
                    Console.WriteLine();
    
                    // Guid length is 16 bytes!
                    byte[] buffer = new byte[16];
                    IntPtr readBytesPtr = IntPtr.Zero;
                    if (!WinApiWrapper.ReadProcessMemory(hProc, pAddr, buffer, buffer.Length, out readBytesPtr))
                    {
                        Console.WriteLine("ReadProcessMemory failed with error: {0}", Marshal.GetLastWin32Error());
                        return;
                    }
                    long readBytes = readBytesPtr.ToInt64();
                    Console.WriteLine("Read {0} bytes from 0x{1:X}", readBytesPtr.ToInt64(), pAddr.ToInt64());
                    Console.Write("Buffer data is: ");
                    ShowBuffer(buffer);
                    Console.WriteLine();
    
                    Guid guid = new Guid(buffer);
                    Console.WriteLine("Buffer as Guid: {0}", guid);
                    if (validGuid == guid)
                        Console.WriteLine("Read memory is OK!");
                    else
                        Console.WriteLine("Read memory failed!");
    
                    Console.WriteLine("Press 'Enter' to quit");
                    Console.ReadLine();
                }
                finally
                {
                    if (hToken != IntPtr.Zero)
                        WinApiWrapper.CloseHandle(hToken);
                    if (hProc != IntPtr.Zero)
                        WinApiWrapper.CloseHandle(hProc);
                }
            }
            private static unsafe void MemoryWriter()
            {
                Console.WriteLine("Mode: Writer");
    
                // Print out current ProcessId. We use it reader!
                Console.WriteLine("Process Id: {0}", Process.GetCurrentProcess().Id);
                // Generate some random bytes
                Guid guid = Guid.NewGuid();
    
                Console.WriteLine("Generated new Guid: {0}", guid);
                byte[] buffer = guid.ToByteArray();
                Console.Write("Guid as byte array: ");
                ShowBuffer(buffer);
                Console.WriteLine();
                fixed (byte* p = buffer)
                {
                    IntPtr bufAddr = new IntPtr((void*)(p));
                    // Print out buffer address. We use it in reader!
                    Console.WriteLine("Buffer address: 0x{0:X}", bufAddr.ToInt64());
                    // Don't press Enter until reader read the memory!
                    Console.WriteLine("Press 'Enter' to quit(Don't press Enter until reader read the memory!)");
                    Console.ReadLine();
                    Console.WriteLine("Buffer address: 0x{0:X}", bufAddr.ToInt64());
                }
            }
            private static void PrintMemInfo(MEMORY_BASIC_INFORMATION memInfo)
            {
                Console.WriteLine("BaseAddress: 0x{0:X}", memInfo.BaseAddress);
                Console.WriteLine("AllocationBase: 0x{0:X}", memInfo.AllocationBase.ToInt64());
                Console.WriteLine("AllocationProtect: {0}", (AllocationProtect)memInfo.AllocationProtect);
                Console.WriteLine("RegionSize: {0}", memInfo.RegionSize);
                Console.WriteLine("Protect: {0}", (AllocationProtect)memInfo.Protect);
                Console.WriteLine("State: {0}", (MemState)memInfo.State);
                Console.WriteLine("Type: {0}", (MemType)memInfo.Type);
            }
            private static void ShowBuffer(byte[] buffer)
            {
                foreach (var b in buffer)
                    Console.Write("{0:x2} ", b);
            }
            private static bool EnablePrivelege()
            {
                IntPtr hToken;
                LUID luidSEDebugNameValue;
                TOKEN_PRIVILEGES tkpPrivileges;
    
                if (!WinApiWrapper.OpenProcessToken(WinApiWrapper.GetCurrentProcess(), (uint)TokenAccess.TOKEN_ADJUST_PRIVILEGES | (uint)TokenAccess.TOKEN_QUERY, out hToken))
                {
                    Console.WriteLine("OpenProcessToken() failed, error = {0} . SeDebugPrivilege is not available", Marshal.GetLastWin32Error());
                    return false;
                }
                else
                {
                    Console.WriteLine("OpenProcessToken() successfully");
                }
    
                if (!WinApiWrapper.LookupPrivilegeValue(null, SePrivilegeNames.SE_DEBUG_NAME, out luidSEDebugNameValue))
                {
                    Console.WriteLine("LookupPrivilegeValue() failed, error = {0} .SeDebugPrivilege is not available", Marshal.GetLastWin32Error());
                    WinApiWrapper.CloseHandle(hToken);
                    return false;
                }
                else
                {
                    Console.WriteLine("LookupPrivilegeValue() successfully");
                }
    
                tkpPrivileges.PrivilegeCount = 1;
                tkpPrivileges.Luid = luidSEDebugNameValue;
                tkpPrivileges.Attributes = (uint)SePrivilege.SE_PRIVILEGE_ENABLED;
    
                bool isOk = true;
                if (!WinApiWrapper.AdjustTokenPrivileges(hToken, false, ref tkpPrivileges, 0, IntPtr.Zero, IntPtr.Zero))
                {
                    Console.WriteLine("LookupPrivilegeValue() failed, error = {0} .SeDebugPrivilege is not available", Marshal.GetLastWin32Error());
                    isOk = false;
                }
                else
                {
                    Console.WriteLine("SeDebugPrivilege is now available");
                }
                WinApiWrapper.CloseHandle(hToken);
                return isOk;
            }
    
        }
    }
    namespace WinApi
    {
        using System;
        using System.Runtime.InteropServices;
        public enum MemState : uint
        {
            MEM_COMMIT = 0x1000,
            MEM_FREE = 0x10000,
            MEM_RESERVE = 0x2000
        }
        public enum MemType : uint
        {
            MEM_IMAGE = 0x1000000,
            MEM_MAPPED = 0x40000,
            MEM_PRIVATE = 0x20000
        }
        [Flags]
        public enum AllocationProtect : uint
        {
            PAGE_EXECUTE = 0x00000010,
            PAGE_EXECUTE_READ = 0x00000020,
            PAGE_EXECUTE_READWRITE = 0x00000040,
            PAGE_EXECUTE_WRITECOPY = 0x00000080,
            PAGE_NOACCESS = 0x00000001,
            PAGE_READONLY = 0x00000002,
            PAGE_READWRITE = 0x00000004,
            PAGE_WRITECOPY = 0x00000008,
            PAGE_GUARD = 0x00000100,
            PAGE_NOCACHE = 0x00000200,
            PAGE_WRITECOMBINE = 0x00000400
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_BASIC_INFORMATION
        {
            public IntPtr BaseAddress;
            public IntPtr AllocationBase;
            public uint AllocationProtect;
            public IntPtr RegionSize;
            public uint State;
            public uint Protect;
            public uint Type;
        }
        public class SePrivilegeNames
        {
            public const string SE_ASSIGNPRIMARYTOKEN_NAME = "SeAssignPrimaryTokenPrivilege";
            public const string SE_AUDIT_NAME = "SeAuditPrivilege";
            public const string SE_BACKUP_NAME = "SeBackupPrivilege";
            public const string SE_CHANGE_NOTIFY_NAME = "SeChangeNotifyPrivilege";
            public const string SE_CREATE_GLOBAL_NAME = "SeCreateGlobalPrivilege";
            public const string SE_CREATE_PAGEFILE_NAME = "SeCreatePagefilePrivilege";
            public const string SE_CREATE_PERMANENT_NAME = "SeCreatePermanentPrivilege";
            public const string SE_CREATE_SYMBOLIC_LINK_NAME = "SeCreateSymbolicLinkPrivilege";
            public const string SE_CREATE_TOKEN_NAME = "SeCreateTokenPrivilege";
            public const string SE_DEBUG_NAME = "SeDebugPrivilege";
            public const string SE_ENABLE_DELEGATION_NAME = "SeEnableDelegationPrivilege";
            public const string SE_IMPERSONATE_NAME = "SeImpersonatePrivilege";
            public const string SE_INC_BASE_PRIORITY_NAME = "SeIncreaseBasePriorityPrivilege";
            public const string SE_INCREASE_QUOTA_NAME = "SeIncreaseQuotaPrivilege";
            public const string SE_INC_WORKING_SET_NAME = "SeIncreaseWorkingSetPrivilege";
            public const string SE_LOAD_DRIVER_NAME = "SeLoadDriverPrivilege";
            public const string SE_LOCK_MEMORY_NAME = "SeLockMemoryPrivilege";
            public const string SE_MACHINE_ACCOUNT_NAME = "SeMachineAccountPrivilege";
            public const string SE_MANAGE_VOLUME_NAME = "SeManageVolumePrivilege";
            public const string SE_PROF_SINGLE_PROCESS_NAME = "SeProfileSingleProcessPrivilege";
            public const string SE_RELABEL_NAME = "SeRelabelPrivilege";
            public const string SE_REMOTE_SHUTDOWN_NAME = "SeRemoteShutdownPrivilege";
            public const string SE_RESTORE_NAME = "SeRestorePrivilege";
            public const string SE_SECURITY_NAME = "SeSecurityPrivilege";
            public const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
            public const string SE_SYNC_AGENT_NAME = "SeSyncAgentPrivilege";
            public const string SE_SYSTEM_ENVIRONMENT_NAME = "SeSystemEnvironmentPrivilege";
            public const string SE_SYSTEM_PROFILE_NAME = "SeSystemProfilePrivilege";
            public const string SE_SYSTEMTIME_NAME = "SeSystemtimePrivilege";
            public const string SE_TAKE_OWNERSHIP_NAME = "SeTakeOwnershipPrivilege";
            public const string SE_TCB_NAME = "SeTcbPrivilege";
            public const string SE_TIME_ZONE_NAME = "SeTimeZonePrivilege";
            public const string SE_TRUSTED_CREDMAN_ACCESS_NAME = "SeTrustedCredManAccessPrivilege";
            public const string SE_UNDOCK_NAME = "SeUndockPrivilege";
            public const string SE_UNSOLICITED_INPUT_NAME = "SeUnsolicitedInputPrivilege";
        }
        [Flags]
        public enum SePrivilege : uint
        {
            SE_PRIVILEGE_ENABLED_BY_DEFAULT = 0x00000001,
            SE_PRIVILEGE_ENABLED = 0x00000002,
            SE_PRIVILEGE_REMOVED = 0x00000004,
            SE_PRIVILEGE_USED_FOR_ACCESS = 0x80000000,
        }
        [Flags]
        public enum TokenAccess : uint
        {
            STANDARD_RIGHTS_REQUIRED = 0x000F0000,
            STANDARD_RIGHTS_READ = 0x00020000,
            TOKEN_ASSIGN_PRIMARY = 0x0001,
            TOKEN_DUPLICATE = 0x0002,
            TOKEN_IMPERSONATE = 0x0004,
            TOKEN_QUERY = 0x0008,
            TOKEN_QUERY_SOURCE = 0x0010,
            TOKEN_ADJUST_PRIVILEGES = 0x0020,
            TOKEN_ADJUST_GROUPS = 0x0040,
            TOKEN_ADJUST_DEFAULT = 0x0080,
            TOKEN_ADJUST_SESSIONID = 0x0100,
            TOKEN_READ = (STANDARD_RIGHTS_READ | TOKEN_QUERY),
            TOKEN_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | TOKEN_ASSIGN_PRIMARY |
                TOKEN_DUPLICATE | TOKEN_IMPERSONATE | TOKEN_QUERY | TOKEN_QUERY_SOURCE |
                TOKEN_ADJUST_PRIVILEGES | TOKEN_ADJUST_GROUPS | TOKEN_ADJUST_DEFAULT |
                TOKEN_ADJUST_SESSIONID)
        }
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct LUID
        {
            public UInt32 LowPart;
            public Int32 HighPart;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct TOKEN_PRIVILEGES
        {
            public UInt32 PrivilegeCount;
            public LUID Luid;
            public UInt32 Attributes;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public struct LUID_AND_ATTRIBUTES
        {
            public LUID Luid;
            public UInt32 Attributes;
        }
        class WinApiWrapper
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);
    
            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern bool OpenProcessToken(IntPtr ProcessHandle, UInt32 DesiredAccess, out IntPtr TokenHandle);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr GetCurrentProcess();
    
            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, out LUID lpLuid);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool CloseHandle(IntPtr hHandle);
    
            // Use this signature if you do not want the previous state
            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern bool AdjustTokenPrivileges(IntPtr TokenHandle, bool DisableAllPrivileges, ref TOKEN_PRIVILEGES NewState, UInt32 Zero, IntPtr Null1, IntPtr Null2);
        }
    }
