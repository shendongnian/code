    public static class ListViewSizer
    {
        const UInt32 LVM_FIRST = 0x1000;
        const UInt32 LVM_GETHEADER = (LVM_FIRST + 31);
        private static int GetHeaderHeight(ListView listView)
        {
            Rect rect = new Rect();
            IntPtr hwnd = SendMessage((IntPtr)listView.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
            if (hwnd != null)
            {
                if (GetWindowRect(new System.Runtime.InteropServices.HandleRef(null, hwnd), out rect))
                {
                    return rect.Bottom - rect.Top;
                }
            }
            return -1;
        }
        public static int GetLastVisibleLine(ListView listView)
        {
            int firstVisibleIndex = listView.TopItem.Index;
            int heightOfFirstItem = listView.GetItemRect(firstVisibleIndex, ItemBoundsPortion.Entire).Height;
            // assuming each item has the same height (I think this is true for list view and details view)
            const int DefaultVisibleLines = 11;
            int visibleLines = heightOfFirstItem != 0 ? (int)Math.Ceiling((decimal)((listView.Height - GetHeaderHeight(listView)) / heightOfFirstItem)) : DefaultVisibleLines;
            int lastVisibleIndexInDetailsMode = firstVisibleIndex + visibleLines;
            return lastVisibleIndexInDetailsMode;
        }
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool GetWindowRect(System.Runtime.InteropServices.HandleRef hwnd, out Rect lpRect);
        [Serializable, System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
