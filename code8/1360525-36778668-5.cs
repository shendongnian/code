    public static class RichTextBoxExtensions
    {
        private const int EM_CHARFROMPOS = 0x00D7;
        public static int GetTrueIndexPositionFromPoint(this RichTextBox rtb, Point pt)
        {
            POINT wpt = new POINT(pt.X, pt.Y);
            int index = (int)SendMessage(new HandleRef(rtb, rtb.Handle), EM_CHARFROMPOS, 0, wpt);
            return index;
        }
        [DllImport("User32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, POINT lParam);
    }
