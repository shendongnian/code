    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    
    namespace TestDesktop
    {
        internal class Program
        {
            private const int UOI_NAME = 2;
            private const int NormalPriorityClass = 0x00000020;
    
            [StructLayout(LayoutKind.Sequential)]
            private struct PROCESS_INFORMATION
            {
                public IntPtr hProcess;
                public IntPtr hThread;
                public int dwProcessId;
                public int dwThreadId;
            }
    
            private struct STARTUPINFO
            {
                public int cb;
                public string lpReserved;
                public string lpDesktop;
                public string lpTitle;
                public int dwX;
                public int dwY;
                public int dwXSize;
                public int dwYSize;
                public int dwXCountChars;
                public int dwYCountChars;
                public int dwFillAttribute;
                public int dwFlags;
                public short wShowWindow;
                public short cbReserved2;
                public IntPtr lpReserved2;
                public IntPtr hStdInput;
                public IntPtr hStdOutput;
                public IntPtr hStdError;
            }
    
            [DllImport("kernel32.dll")]
            private static extern bool CreateProcess(
                string lpApplicationName,
                string lpCommandLine,
                IntPtr lpProcessAttributes,
                IntPtr lpThreadAttributes,
                bool bInheritHandles,
                int dwCreationFlags,
                IntPtr lpEnvironment,
                string lpCurrentDirectory,
                ref STARTUPINFO lpStartupInfo,
                ref PROCESS_INFORMATION lpProcessInformation
                );
    
            [DllImport("user32.dll")]
            public static extern IntPtr CreateDesktop(string lpszDesktop, IntPtr lpszDevice, IntPtr pDevmode, int dwFlags,
                uint dwDesiredAccess, IntPtr lpsa);
    
            [DllImport("user32.dll")]
            private static extern bool SwitchDesktop(IntPtr hDesktop);
    
            [DllImport("user32.dll")]
            public static extern bool CloseDesktop(IntPtr handle);
    
            [DllImport("user32.dll")]
            public static extern bool SetThreadDesktop(IntPtr hDesktop);
    
            [DllImport("user32.dll")]
            public static extern IntPtr GetThreadDesktop(int dwThreadId);
    
            public delegate bool EnumDelegate(IntPtr hWnd, int lParam);
    
            [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows",
            ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDelegate lpEnumCallbackFunction, IntPtr lParam);
    
            [DllImport("user32.dll", EntryPoint = "GetWindowText",
            ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxCount);
    
            [DllImport("user32.dll")]
            private static extern bool GetUserObjectInformation(IntPtr hObj, int nIndex, IntPtr pvInfo, int nLength,
                ref int lpnLengthNeeded);
    
            [DllImport("user32.dll")]
            static extern bool CloseWindow(IntPtr hWnd);
    
            [DllImport("user32.dll", SetLastError = true)]
            static extern uint GetWindowThreadProcessId(IntPtr hWnd, ref int lpdwProcessId);
    
            [DllImport("kernel32.dll")]
            public static extern int GetCurrentThreadId();
    
    
            private enum DesktopAccess : uint
            {
                DesktopNone = 0,
                DesktopReadobjects = 0x0001,
                DesktopCreatewindow = 0x0002,
                DesktopCreatemenu = 0x0004,
                DesktopHookcontrol = 0x0008,
                DesktopJournalrecord = 0x0010,
                DesktopJournalplayback = 0x0020,
                DesktopEnumerate = 0x0040,
                DesktopWriteobjects = 0x0080,
                DesktopSwitchdesktop = 0x0100,
    
                GenericAll = (DesktopReadobjects | DesktopCreatewindow | DesktopCreatemenu
                              | DesktopHookcontrol
                              | DesktopJournalrecord | DesktopJournalplayback |
                              DesktopEnumerate | DesktopWriteobjects | DesktopSwitchdesktop),
            }
    
            public static string GetDesktopName(IntPtr desktopHandle)
            {
                // check its not a null pointer.
                // null pointers wont work.
                if (desktopHandle == IntPtr.Zero) return null;
    
                // get the length of the name.
                var needed = 0;
                var name = String.Empty;
                GetUserObjectInformation(desktopHandle, UOI_NAME, IntPtr.Zero, 0, ref needed);
    
                // get the name.
                var ptr = Marshal.AllocHGlobal(needed);
                var result = GetUserObjectInformation(desktopHandle, UOI_NAME, ptr, needed, ref needed);
                name = Marshal.PtrToStringAnsi(ptr);
                Marshal.FreeHGlobal(ptr);
    
                // something went wrong.
                if (!result) return null;
    
                return name;
            }
    
            public static bool KillAllProcess(string desktopName, IntPtr hNewDesktop)
            {
                var collection = new List<string>();
                var thisProc = Process.GetCurrentProcess();
    
                EnumDelegate filter = delegate(IntPtr hWnd, int lParam)
                {
                    var processId = 0;
                    var threadID = GetWindowThreadProcessId(hWnd, ref processId);
                    try
                    {
                        if (thisProc.Id != processId)
                        {
                            var proc = Process.GetProcessById(processId);
                            proc.Kill();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return true;
                    }
                    return true;
                };
    
                return EnumDesktopWindows(hNewDesktop, filter, IntPtr.Zero);
            }
    
            static void Main()
            {
                const string newDesktopName = "RandomDesktopName";
                // old desktop's handle, obtained by getting the current desktop assigned for this thread
                var hOldDesktop = GetThreadDesktop(GetCurrentThreadId());
    
                // new desktop's handle, assigned automatically by CreateDesktop
                var hNewDesktop = CreateDesktop(newDesktopName, IntPtr.Zero, IntPtr.Zero, 0, (uint)DesktopAccess.GenericAll, IntPtr.Zero);
    
                // switching to the new desktop
                SwitchDesktop(hNewDesktop);
                // assigning the new desktop to this thread - so the Form will be shown in the new desktop)
                SetThreadDesktop(hNewDesktop);
    
                var si = new STARTUPINFO();
                si.cb = Marshal.SizeOf(si);
                si.lpDesktop = newDesktopName;
    
                var pi = new PROCESS_INFORMATION();
    
                // start the process.
                CreateProcess(null, "explorer.exe", IntPtr.Zero, IntPtr.Zero, true, NormalPriorityClass, IntPtr.Zero, null, ref si, ref pi);
    
                var loginWnd = new Form();
                var btn = new Button { Text = "Close" };
                btn.Click += (sender1, ex1) =>
                {
                    SwitchDesktop(hOldDesktop);
                    KillAllProcess(newDesktopName, hNewDesktop);
                    loginWnd.Close();
                };
                loginWnd.Controls.Add(btn);
                Application.Run(loginWnd);
    
    
                SwitchDesktop(hOldDesktop);
                CloseDesktop(hNewDesktop);
    
                Console.ReadKey();
            }
        }
    }
