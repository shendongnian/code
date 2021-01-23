    public static class WndSearcher
    {
        public static IntPtr SearchForWindow(string wndclass, string title)
        {
            var sd = new SearchData { Wndclass = wndclass, Title = title };
            
            EnumWindows(sd.EnumWindowsProc, IntPtr.Zero);
            return sd.hWndFound;
        }
        private class SearchData
        {
            // You can put any dicks or Doms in here...
            public string Wndclass;
            public string Title;
            public IntPtr hWndFound;
            public bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam)
            {
                // Check classname and title 
                var sb = new StringBuilder(1024);
                int res = GetClassName(hWnd, sb, sb.Capacity);
                if (res == 0)
                {
                    throw new Win32Exception();
                }
                if (sb.ToString().StartsWith(Wndclass, StringComparison.CurrentCultureIgnoreCase))
                {
                    sb.Clear();
                    res = GetWindowText(hWnd, sb, sb.Capacity);
                    if (res == 0)
                    {
                        int error = Marshal.GetLastWin32Error();
                        if (error != 0) 
                        {
                            throw new Win32Exception(error);
                        }
                    }
                    if (sb.ToString().StartsWith(Title, StringComparison.CurrentCultureIgnoreCase))
                    {
                        hWndFound = hWnd;
                        // Found the wnd, halt enumeration
                        return false;    
                    }
                }
                return true;
            }
        }
        [return: MarshalAs(UnmanagedType.Bool)]
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    }
