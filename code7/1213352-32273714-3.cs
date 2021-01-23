    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class KeyboardHook : IDisposable
    {
        #region Fields
        private bool _lControlKeyIsDown;
        private bool _rControlKeyIsDown;
        private bool _lShiftKeyIsDown;
        private bool _rShiftKeyIsDown;
        #endregion
        #region Properties
        private bool ControlIsDown
        {
           get { return _lControlKeyIsDown || _rControlKeyIsDown; }
        }
        private bool ShiftIsDown
        {
            get { return _lShiftKeyIsDown || _rShiftKeyIsDown; }
        }
        #endregion
        #region Constructors
        public KeyboardHook()
        {
            _proc = HookCallback;
        }
        #endregion
        #region Events
        public event HookKeyDownHandler KeyDown;
        #endregion
        #region Methods
        public void Start()
        {
            _hookID = SetHook(_proc);
        }
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var vkCode = Marshal.ReadInt32(lParam);
                var key = (Keys)vkCode;
                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    switch (key)
                    {
                        case Keys.LControlKey:
                            _lControlKeyIsDown = true;
                            break;
                        case Keys.RControlKey:
                            _rControlKeyIsDown = true;
                            break;
                        case Keys.LShiftKey:
                            _lShiftKeyIsDown = true;
                            break;
                        case Keys.RShiftKey:
                            _rShiftKeyIsDown = true;
                            break;
                        default:
                            if (KeyDown != null)
                            {
                                var args = new HookKeyDownEventArgs((Keys)vkCode, ShiftIsDown, ControlIsDown);
                                KeyDown(this, args);
                            }
                            break;
                    }
                }
                if (wParam == (IntPtr)WM_KEYUP)
                {
                    switch (key)
                    {
                        case Keys.LControlKey:
                            _lControlKeyIsDown = false;
                            break;
                        case Keys.RControlKey:
                            _rControlKeyIsDown = false;
                            break;
                        case Keys.LShiftKey:
                            _lShiftKeyIsDown = false;
                            break;
                        case Keys.RShiftKey:
                            _rShiftKeyIsDown = false;
                            break;
                    }
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
        public void Release()
        {
            UnhookWindowsHookEx(_hookID);
        }
        public void Dispose()
        {
            Release();
        }
        #endregion
        #region Interoperability
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private readonly LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion
    }
	
	public class HookKeyDownEventArgs : EventArgs
    {
        #region Fields
        private readonly Keys _key;
        private readonly bool _shift;
        private readonly bool _control;
        #endregion
        #region Properties
        public Keys Key
        {
            get { return _key; }
        }
        public bool Shift
        {
            get { return _shift; }
        }
        public bool Control
        {
            get { return _control; }
        }
        #endregion
        #region Constructors
        public HookKeyDownEventArgs(Keys key, bool shift, bool control)
        {
            _key = key;
            _shift = shift;
            _control = control;
        }
        #endregion
    }
	
	public delegate void HookKeyDownHandler(object sender, HookKeyDownEventArgs e);
