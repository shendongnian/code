    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    public class ProcessFileNameFinderClass
    {
        public static HashSet<string> GetAllRunningProcessFilePaths()
        {
            var allProcesses = System.Diagnostics.Process.GetProcesses();
            HashSet<string> ProcessExeNames = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
            foreach (Process p in allProcesses)
            {
                string processExePath = GetProcessExecutablePath(p);
                ProcessExeNames.Add(System.IO.Path.GetFileName(processExePath));
            }
            return ProcessExeNames;
        }
    
        /// <summary>
        /// Get executable path of running process
        /// </summary>
        /// <param name="Process"></param>
        /// <returns></returns>
        public static string GetProcessExecutablePath(Process Process)
        {
            try
            {
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    return GetExecutablePathAboveXP(Process.Id);// this gets the process file name without running as administrator 
                }
                return Process.MainModule.FileName;// Vista and later this requires running as administrator.
            }
            catch
            {
                return "";
            }
        }
        public static string GetExecutablePathAboveXP(int ProcessId)
        {
            int MAX_PATH = 260;
            StringBuilder sb = new StringBuilder(MAX_PATH + 1);
            IntPtr hprocess = OpenProcess(ProcessAccessFlags.PROCESS_QUERY_LIMITED_INFORMATION, false, ProcessId);
            if (hprocess != IntPtr.Zero)
            {
                try
                {
                    int size = sb.Capacity;
                    if (QueryFullProcessImageName(hprocess, 0, sb, ref size))
                    {
                        return sb.ToString();
                    }
                }
                finally
                {
                    CloseHandle(hprocess);
                }
            }
            return "";
        }
        [Flags()]
        private enum ProcessAccessFlags : uint
        {
            PROCESS_ALL_ACCESS = 0x1f0fff,
            PROCESS_TERMINATE = 0x1,
            PROCESS_CREATE_THREAD = 0x2,
            PROCESS_VM_OPERATION = 0x8,
            PROCESS_VM_READ = 0x10,
            PROCESS_VM_WRITE = 0x20,
            PROCESS_DUP_HANDLE = 0x40,
            PROCESS_SET_INFORMATION = 0x200,
            PROCESS_SET_QUOTA = 0x100,
            PROCESS_QUERY_INFORMATION = 0x400,
            PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,
            SYNCHRONIZE = 0x100000,
            PROCESS_CREATE_PROCESS = 0x80,
            PROCESS_SUSPEND_RESUME = 0x800
        }
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool QueryFullProcessImageName(IntPtr hProcess, uint dwFlags, [Out(), MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpExeName, ref int lpdwSize);
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hHandle);
    }
