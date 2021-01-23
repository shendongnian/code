    public partial class ThisAddIn
    {
        public MyNativeWindow MyNativeExcelWindow { get; private set; }
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            var excelHwnd_IntPtr = new IntPtr(Globals.ThisAddIn.Application.Hwnd);
            MyNativeExcelWindow = new MyNativeWindow();
            MyNativeExcelWindow.AssignHandle(excelHwnd_IntPtr);
            ...
        } 
        ...
    }
    public class MyNativeWindow : NativeWindow
    {
        private const int WM_CLOSE = 16;
        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CLOSE) 
            {
                // Release handle for this native window before closing app...
                ReleaseHandle();
                // Then go on closing...
                PostMessage(m.HWnd, Convert.ToUInt32(m.Msg), m.WParam.ToInt32(), m.LParam.ToInt32());
            }
            else
            {
                // HERE YOU CAN PROCESS OTHER MESSAGES...
                base.WndProc(ref m);
            }
        }
    }
