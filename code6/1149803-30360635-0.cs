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
    	Point ptClick = Control.MousePosition;
    
    	// Correct for the location of the (Top,Left edge) of the form
    	ptClick.X -= (pnlButtons.Parent.Left + pnlButtons.Left);
    	ptClick.Y -= (pnlButtons.Parent.Top + pnlButtons.Top);
    
    	// Now look for any Button / PictureBox controls nearby
    	foreach (Control cntrl in pnlButtons.Controls)
    	{
    		// Make sure the control is visible!
    		if (cntrl.Visible)
    		{
    			// Is the click close to this control?
    			if ((ptClick.X > (cntrl.Left - 4)) &&
    				(ptClick.X < (cntrl.Right + 4)) &&
    				(ptClick.Y > (cntrl.Top - 5)) &&
    				(ptClick.Y < (cntrl.Bottom + 5)))
    			{
    				// Simulate a click on the control
    				ClickControl(cntrl.Handle);
    				break;
    			}
    		}
    	}
    }
