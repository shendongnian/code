    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    namespace Util
    {
        /// <summary>
        /// Utility methods for processes
        /// </summary>
        public static class ProcessUtil
        {
            //Code is inspired by http://www.pinvoke.net/default.aspx/kernel32.createtoolhelp32snapshot
            [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
            static extern IntPtr CreateToolhelp32Snapshot([In]UInt32 dwFlags, [In]UInt32 th32ProcessID);
            [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
            static extern bool Process32First([In]IntPtr hSnapshot, ref PROCESSENTRY32 lppe);
            [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
            static extern bool Process32Next([In]IntPtr hSnapshot, ref PROCESSENTRY32 lppe);
            [DllImport("kernel32", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CloseHandle([In] IntPtr hObject);
            //inner enum used only internally
            [Flags]
            private enum SnapshotFlags : uint
            {
                HeapList = 0x00000001,
                Process = 0x00000002,
                Thread = 0x00000004,
                Module = 0x00000008,
                Module32 = 0x00000010,
                Inherit = 0x80000000,
                All = 0x0000001F,
                NoHeaps = 0x40000000
            }
            //inner struct used only internally
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            private struct PROCESSENTRY32
            {
                const int MAX_PATH = 260;
                internal UInt32 dwSize;
                internal UInt32 cntUsage;
                internal UInt32 th32ProcessID;
                internal IntPtr th32DefaultHeapID;
                internal UInt32 th32ModuleID;
                internal UInt32 cntThreads;
                internal UInt32 th32ParentProcessID;
                internal Int32 pcPriClassBase;
                internal UInt32 dwFlags;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
                internal string szExeFile;
            }
            /// <summary>
            /// Returns a list with running processes for a given executable path.
            /// </summary>
            /// <param name="exec">full path to the executable</param>
            /// <returns>a list containing all processes currently run by the given executable</returns>
            public static List<Process> GetProcessesForExecutable(string exec)
            {            
                List<Process> toReturn = new List<Process>();
                IntPtr handleToSnapShot = IntPtr.Zero;
                FileInfo fi = new FileInfo(exec);
                if (!fi.Exists)
                {               
                    return toReturn;
                }
                try
                {
                    PROCESSENTRY32 procEntry = new PROCESSENTRY32();
                    procEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(PROCESSENTRY32));
                    handleToSnapShot = CreateToolhelp32Snapshot((uint)SnapshotFlags.Process, 0);
                    if (Process32First(handleToSnapShot, ref procEntry))
                    {
                        do
                        {
                            if (fi.Name.Equals(procEntry.szExeFile))
                            {
                                Process p = Process.GetProcessById((int)procEntry.th32ProcessID);
                                if (p.MainModule.FileName.Equals(fi.FullName))
                                    toReturn.Add(p);
                            }
                        } while (Process32Next(handleToSnapShot, ref procEntry));
                    }
                }
                catch (Exception ex)
                {
                    //some error handling would be neccessary here
                }
                finally
                {
                    CloseHandle(handleToSnapShot);
                }
                return toReturn;
            }
        }
    }
