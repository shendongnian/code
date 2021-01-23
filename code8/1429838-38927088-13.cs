    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    public static class MouseHook
    {
        public static event EventHandler MouseAction = delegate { };
        private static Win32.LowLevelMouseProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        public static void Start() { _hookID = SetHook(_proc); }
        public static void Stop() { Win32.UnhookWindowsHookEx(_hookID); }
        private static IntPtr SetHook(Win32.LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                var handle = Win32.GetModuleHandle(curModule.ModuleName);
                return Win32.SetWindowsHookEx(Win32.WH_MOUSE_LL, proc, handle, 0);
            }
        }
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && 
                Win32.MouseMessages.WM_RBUTTONDOWN == (Win32.MouseMessages)wParam)
            {
                Win32.MSLLHOOKSTRUCT hookStruct = 
                    (Win32.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, 
                        typeof(Win32.MSLLHOOKSTRUCT));
                MouseAction(null, new EventArgs());
            }
            return Win32.CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
