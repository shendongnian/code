        private const uint GA_ROOT = 2;
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(int xPoint, int yPoint);
        [System.Runtime.InteropServices.DllImport("user32.dll", ExactSpelling = true)]
        private static extern IntPtr GetAncestor(IntPtr hwnd, uint gaFlags);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                label1.DoDragDrop(label1, DragDropEffects.Copy);
            }
        }
        private void label1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            Point pt = Cursor.Position;
            IntPtr wnd = WindowFromPoint(pt.X, pt.Y);
            IntPtr mainWnd = GetAncestor(wnd, GA_ROOT);
            POINT PT;
            PT.X = pt.X;
            PT.Y = pt.Y;
            ScreenToClient(mainWnd, ref PT);
            this.Text = String.Format("({0}, {1})", PT.X.ToString(), PT.Y.ToString());
        }
