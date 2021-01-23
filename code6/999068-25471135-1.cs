    internal class NativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowCaret(IntPtr hwnd);
        
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HideCaret(IntPtr hwnd);
    }
    public class ReadOnlyTextBox : System.Windows.Forms.TextBox
    {
        public ReadOnlyTextBox()
        {
            this.ReadOnly = true;
        }
        
        protected override void OnGotFocus(EventArgs e)
        {
            NativeMethods.HideCaret(this.Handle);
        }
        
        protected override void OnLostFocus(EventArgs e)
        {
            NativeMethods.ShowCaret(this.Handle);
        }
    }
