        private const int WM_NCACTIVATE = 0x86;
    
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    
        protected override void WndProc(ref Message m)
        {
            // The popup needs to be activated for the user to interact with it,
            // but we want to keep the owner window's appearance the same.
            if ((m.Msg == WM_NCACTIVATE) && !_activating && (m.WParam != IntPtr.Zero))
            {
                // The popup is being activated, ensure parent keeps activated appearance
                _activating = true;
                SendMessage(this.Owner.Handle, WM_NCACTIVATE, (IntPtr) 1, IntPtr.Zero);
                _activating = false;
                // Call base.WndProc here if you want the appearance of the popup to change
            }
            else
            {
                base.WndProc(ref m);
            }
        }
