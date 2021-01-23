        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPthWndNewParent);
        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool repaint);
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        private struct RECT { public int Left; public int Top; public int Right; public int Bottom; }
        
