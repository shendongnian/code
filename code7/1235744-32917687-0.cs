    protected override void WndProc( ref Message m )
        {
            base.WndProc(ref m); // Call overwritten method first
            if( m.Msg == 0x0112 ) // WM_SYSCOMMAND
            {
                if (m.WParam == new IntPtr( 0xF030 ) ) //Window is being maximized
                {
                      // things
                }
            }
        }
