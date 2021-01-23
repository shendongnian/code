        // ... at Form level ...
        private const int WM_SETREDRAW = 11; 
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        // ... some method ...
            SendMessage(this.Handle, WM_SETREDRAW, false, 0); // turn updates off
            this.Controls.Remove(ctlAvion); // Removes the actual UserControl (red rectangle)
            ctlAvion = new ControlAvion(m_avion); // Creates a new one
            ctlAvion.Location = new Point(2, 13);
            ctlAvion.Size = new Size(597, 475);
            this.Controls.Add(ctlAvion); // Adds the new UserControl to the main controls (a Form).
            SendMessage(this.Handle, WM_SETREDRAW, true, 0); // turn updates back on
            this.Invalidate();
            this.Refresh();
