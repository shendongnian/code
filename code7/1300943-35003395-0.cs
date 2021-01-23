    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    public static class MouseHook
    {
        public class MSLLHOOKSTRUCTEventArgs : EventArgs
        {
            private readonly MSLLHOOKSTRUCT _hookStruct;
            public MSLLHOOKSTRUCTEventArgs(MSLLHOOKSTRUCT hookStruct)
            {
                _hookStruct = hookStruct;
            }
            public MSLLHOOKSTRUCT HookStruct
            {
                get { return _hookStruct; }
            }
        }
        public static event EventHandler<MSLLHOOKSTRUCTEventArgs> MouseDown = delegate { };
        public static event EventHandler<MSLLHOOKSTRUCTEventArgs> MouseUp = delegate { };
        public static event EventHandler<MSLLHOOKSTRUCTEventArgs> MouseMove = delegate { };
        public static bool Started { get; set; }
        static MouseHook()
        {
            Started = false;
        }
        public static void Start()
        {
            Debug.WriteLine("MouseHook.Start");
            _hookID = SetHook(_proc);
            Started = true;
        }
        public static void Stop()
        {
            Debug.WriteLine("MouseHook.Stop");
            UnhookWindowsHookEx(_hookID);
            Started = false;
            MouseDown = null;
            MouseUp = null;
            MouseMove = null;
        }
        private static LowLevelMouseProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            IntPtr hook = SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle("user32"), 0);
            if (hook == IntPtr.Zero)
                throw new System.ComponentModel.Win32Exception();
            return hook;
        }
        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                if (MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
                {
                    if(MouseDown!=null)
                        MouseDown(null, new MSLLHOOKSTRUCTEventArgs(hookStruct));
                }
                else if (MouseMessages.WM_LBUTTONUP == (MouseMessages)wParam)
                {
                    if (MouseUp != null)
                        MouseUp(null, new MSLLHOOKSTRUCTEventArgs(hookStruct));
                }
                else
                {
                    if (MouseMove != null)
                        MouseMove(null, new MSLLHOOKSTRUCTEventArgs(hookStruct));
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
        private const int WH_MOUSE = 7;
        private const int WH_MOUSE_LL = 14;
        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
