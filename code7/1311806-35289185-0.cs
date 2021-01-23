    public class KeyboardDirectInput
    {
        [DllImport("user32.dll")]
        static extern UInt32 SendInput(UInt32 nInputs, [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] INPUT[] pInputs, Int32 cbSize);
        public void Press(short scanCode)
        {
            INPUT[] InputData = new INPUT[2];
            InputData[0].type = (int)InputType.INPUT_KEYBOARD;
            InputData[0].ki.wScan = (short)scanCode;
            InputData[0].ki.dwFlags = (int)KEYEVENTF.SCANCODE;
            InputData[1].type = (int)InputType.INPUT_KEYBOARD;
            InputData[1].ki.wScan = (short)scanCode;
            InputData[1].ki.dwFlags = (int)(KEYEVENTF.KEYUP | KEYEVENTF.UNICODE);
            if (SendInput(2, InputData, Marshal.SizeOf(InputData[1])) == 0)
            {
                System.Diagnostics.Debug.WriteLine("SendInput failed (CODE {0})", Marshal.GetLastWin32Error());
            }
        }
        [StructLayout(LayoutKind.Explicit)]
        public struct INPUT
        {
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public int type;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }
        [Flags]
        public enum KEYEVENTF
        {
            KEYDOWN = 0,
            EXTENDEDKEY = 0x0001,
            KEYUP = 0x0002,
            UNICODE = 0x0004,
            SCANCODE = 0x0008,
        }
        [Flags]
        public enum InputType
        {
            INPUT_MOUSE = 0,
            INPUT_KEYBOARD = 1,
            INPUT_HARDWARE = 2
        }
    }
