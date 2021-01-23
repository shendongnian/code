        [DllImport("USER32.DLL")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        //int x = 300; int y = 200; string windowName = "Form1"; int width = 200; int height = 100;
        /// <summary>
        /// moves a window and resizes it accordingly
        /// </summary>
        /// <param name="x">x position to move to</param>
        /// <param name="y">y position to move to</param>
        /// <param name="windowName">the window to move</param>
        /// <param name="width">the window's new width</param>
        /// <param name="height">the window's new height</param>
        public static void WindowMove(int x, int y, string windowName, int width, int height)
        {
            IntPtr window = FindWindow(null, windowName);
            if (window != IntPtr.Zero) { MoveWindow(window, x, y, width, height, true); }
            //IntPtr window = FindWindow(null, windowName);
            //if (IntPtr.Zero != [B]window[/B]) { MoveWindow(window, x, y, width, height, true); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            WindowMove(200, 200, "Form1", 400, 200);
        }
