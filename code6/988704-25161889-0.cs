    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT
    {
      internal uint type;
      internal KEYBDINPUT ki;
      internal static int Size
      {
         get { return Marshal.SizeOf(typeof(INPUT)); }
      }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    internal struct KEYBDINPUT
    {
        internal short wVk;
        internal short wScan;
        internal uint dwFlags;
        internal uint time;
        internal IntPtr dwExtraInfo;
    }
    var pInputs = new[] { 
                    new INPUT() {
                         type = 0×01; //INPUT_KEYBOARD
                         ki = new KEYBDINPUT() {
                              wVk = 0×90; //VK_NUMLOCK
                              wScan = 0;
                              dwFlags = 0; //key-down
                              time = 0;
                              dwExtraInfo = IntPtr.Zero;
                         },
                    new INPUT() {
                         type = 0×01; //INPUT_KEYBOARD
                         ki = new KEYBDINPUT() {
                              wVk = 0×90; //VK_NUMLOCK
                              wScan = 0;
                              dwFlags = 2; //key-up
                              time = 0;
                              dwExtraInfo = IntPtr.Zero;
                         },
                  };
    SendInput((uint)pInputs.Length, pInputs, INPUT.Size);
