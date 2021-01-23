    public static class User32
    {
        [DllImport("user32.dll")]
        public static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);
    }
    public class CustomMenuTextBox : TextBox
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0093 /*WM_UAHINITMENU*/ || m.Msg == 0x0117 /*WM_INITMENUPOPUP*/ || m.Msg == 0x0116 /*WM_INITMENU*/)
            {
                IntPtr menuHandle = m.Msg == 0x0093 ? Marshal.ReadIntPtr(m.LParam) : m.WParam;
                // MF_BYPOSITION and MF_GRAYED
                User32.EnableMenuItem(menuHandle, 4, 0x00000400 | 0x00000001);
            }
            base.WndProc(ref m);
        }
    }
