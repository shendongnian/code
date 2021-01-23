    internal static class WindowExtensions
    {
        [DllImport("user32.dll")]
        internal extern static int SetWindowLong(IntPtr hwnd, int index, int value);
     
        [DllImport("user32.dll")]
        internal extern static int GetWindowLong(IntPtr hwnd, int index);
     
        internal static void HideMinimizeAndMaximizeButtons(this Window window)
        {
            const int GWL_STYLE = -16;
     
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(window).Handle;
            long value = GetWindowLong(hwnd, GWL_STYLE);
     
            SetWindowLong(hwnd, GWL_STYLE, (int)(value & -131073 & -65537));
     
        }
    }
     
    this.SourceInitialized += (x, y) =>
    {
        this.HideMinimizeAndMaximizeButtons();
    };
