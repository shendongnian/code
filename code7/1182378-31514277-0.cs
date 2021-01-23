    public class ProcessHelper
    {
        public const Int32 USE_STD_HANDLES = 0x00000100;
        public const Int32 STD_OUTPUT_HANDLE = -11;
        public const Int32 STD_ERROR_HANDLE = -12;
        //this flag instructs StartProcessWithLogonW to consider the value StartupInfo.showWindow when creating the process
        public const Int32 STARTF_USESHOWWINDOW = 0x00000001;
        public static ProcessStartResult StartProcess(string exe,
                                                      string[] args = null,
                                                      bool isHidden = false,
                                                      bool waitForExit = false,
                                                      uint waitTimeout = 0)
        {
            string command;
            var startupInfo = CreateStartupInfo(exe, args, isHidden, out command);
            ProcessInformation processInfo;
            var processSecAttributes = new SecurityAttributes();
            processSecAttributes.Length = Marshal.SizeOf(processSecAttributes);
            var threadSecAttributes = new SecurityAttributes();
            threadSecAttributes.Length = Marshal.SizeOf(threadSecAttributes);
            CreationFlags creationFlags = 0;
            if (isHidden)
            {
                creationFlags = CreationFlags.CreateNoWindow;
            }
            var started = Win32Api.CreateProcess(exe,
                                                    command,
                                                    ref processSecAttributes,
                                                    ref threadSecAttributes,
                                                    false,
                                                    Convert.ToInt32(creationFlags),
                                                    IntPtr.Zero,
                                                    null,
                                                    ref startupInfo,
                                                    out processInfo);
            var result = CreateProcessStartResult(waitForExit, waitTimeout, processInfo, started);
            return result;
        }
        private static StartupInfo CreateStartupInfo(string exe, string[] args, bool isHidden, out string command)
        {
            var startupInfo = new StartupInfo();
            startupInfo.Flags &= USE_STD_HANDLES;
            startupInfo.StdOutput = (IntPtr) STD_OUTPUT_HANDLE;
            startupInfo.StdError = (IntPtr) STD_ERROR_HANDLE;
            if (isHidden)
            {
                startupInfo.ShowWindow = 0;
                startupInfo.Flags = STARTF_USESHOWWINDOW;
            }
            var argsWithExeName = new string[args.Length + 1];
            argsWithExeName[0] = exe;
            args.CopyTo(argsWithExeName, 1);
            var argsString = ToCommandLineArgsString(argsWithExeName);
            command = argsString;
            return startupInfo;
        }
        private static string ToCommandLineArgsString(Array array)
        {
            var argumentsBuilder = new StringBuilder();
            foreach (var item in array)
            {
                if (item != null)
                {
                    var escapedArgument = item.ToString().Replace("\"", "\"\"");
                    argumentsBuilder.AppendFormat("\"{0}\" ", escapedArgument);
                }
            }
            return argumentsBuilder.ToString();
        }
        private static ProcessStartResult CreateProcessStartResult(bool waitForExit, uint waitTimeout,
            ProcessInformation processInfo, bool started)
        {
            uint exitCode = 0;
            var hasExited = false;
            if (started && waitForExit)
            {
                var waitResult = Win32Api.WaitForSingleObject(processInfo.Process, waitTimeout);
                if (waitResult == WaitForSingleObjectResult.WAIT_OBJECT_0)
                {
                    Win32Api.GetExitCodeProcess(processInfo.Process, ref exitCode);
                    hasExited = true;
                }
            }
            var result = new ProcessStartResult()
            {
                ExitCode = (int) exitCode,
                Started = started,
                HasExited = hasExited
            };
            return result;
        }
    }
    [Flags]
    public enum CreationFlags
    {
        CreateSuspended = 0x00000004,
        CreateNewConsole = 0x00000010,
        CreateNewProcessGroup = 0x00000200,
        CreateNoWindow = 0x08000000,
        CreateUnicodeEnvironment = 0x00000400,
        CreateSeparateWowVdm = 0x00000800,
        CreateDefaultErrorMode = 0x04000000,
    }
    public struct ProcessInformation
    {
        public IntPtr Process { get; set; }
        public IntPtr Thread { get; set; }
        public int ProcessId { get; set; }
        public int ThreadId { get; set; }
    }
    public class ProcessStartResult
    {
        public bool Started { get; set; }
  
        public int ExitCode { get; set; }
        public bool HasExited { get; set; }
        public Exception Error { get; set; }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SecurityAttributes
    {
        public int Length;
        public IntPtr SecurityDescriptor;
        public int InheritHandle;
    }
    public struct StartupInfo
    {
        public int Cb;
        public String Reserved;
        public String Desktop;
        public String Title;
        public int X;
        public int Y;
        public int XSize;
        public int YSize;
        public int XCountChars;
        public int YCountChars;
        public int FillAttribute;
        public int Flags;
        public UInt16 ShowWindow;
        public UInt16 Reserved2;
        public byte Reserved3;
        public IntPtr StdInput;
        public IntPtr StdOutput;
        public IntPtr StdError;
    }
    public static class WaitForSingleObjectResult
    {
        /// <summary>
        /// The specified object is a mutex object that was not released by the thread that owned the mutex
        /// object before the owning thread terminated. Ownership of the mutex object is granted to the 
        /// calling thread and the mutex state is set to nonsignaled
        /// </summary>
        public const UInt32 WAIT_ABANDONED = 0x00000080;
        /// <summary>
        /// The state of the specified object is signaled.
        /// </summary>
        public const UInt32 WAIT_OBJECT_0 = 0x00000000;
        /// <summary>
        /// The time-out interval elapsed, and the object's state is nonsignaled.
        /// </summary>
        public const UInt32 WAIT_TIMEOUT = 0x00000102;
    }
    public class Win32Api
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetExitCodeProcess(IntPtr process, ref UInt32 exitCode);
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern UInt32 WaitForSingleObject(IntPtr handle, UInt32 milliseconds);
        [DllImport("kernel32.dll")]
        public static extern bool CreateProcess
            (string lpApplicationName,
                string lpCommandLine,
                ref SecurityAttributes lpProcessAttributes,
                ref SecurityAttributes lpThreadAttributes,
                bool bInheritHandles,
                Int32 dwCreationFlags,
                IntPtr lpEnvironment,
                string lpCurrentDirectory,
                [In] ref StartupInfo lpStartupInfo,
                out ProcessInformation lpProcessInformation);
    }
