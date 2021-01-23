    // Windows constants for mouse messages
    private const int WM_LBUTTONDOWN		= 0x0201;
    private const int WM_LBUTTONUP			= 0x0202;
    
    // P/Invoke for SendMessage
    [DllImport("coredll.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int nMsg, IntPtr wParam, IntPtr lParam);
    
    // Method to click a control
    public void ClickControl(IntPtr hWnd)
    {
    	// Send a MOUSE_DOWN and MOUSE_UP message to the control to simulate a click
    	SendMessage(hWnd, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
    	SendMessage(hWnd, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
    }
    
    // Method to handle click event on parent Panel control
    private void pnlButtons_Click(object sender, EventArgs e)
    {
    	// See if the click point is close to a (visible) button and if so, click the button.
    	// The user was probably a little imprecise or the screen might need re-calibration.
        Point pt = pnlButtons.PointToClient(Cursor.Position);
    	   
    	// Now look for any Button / PictureBox controls nearby
    	foreach (Control cntrl in pnlButtons.Controls.Where(c => c.Visible))
    	{
    		if(Rectangle.Inflate(cntrl.Bounds, 4, 5).Contains(pt))
            {
                // Simulate a click on the control
    		    ClickControl(cntrl.Handle);
    			break;
            }
    	}
    }
