    class MyTextBox : TextBox
    {
    	protected override void WndProc(ref Message m)
    	{
    		const int WM_LBUTTONDOWN = 0x0201;
    		const int WM_MOUSEACTIVATE = 0x0021;
    		const int MA_ACTIVATEANDEAT = 2;
    		const int MA_NOACTIVATEANDEAT = 4;
    
    		if (m.Msg == WM_MOUSEACTIVATE && !Focused)
    		{
    			int mouseMsg = unchecked((int)((uint)(int)m.LParam >> 16)); // LOWORD(m.LParam)
    			if (mouseMsg == WM_LBUTTONDOWN)
    			{
    				bool activated = Focus();
    				m.Result = (IntPtr)(activated ? MA_ACTIVATEANDEAT : MA_NOACTIVATEANDEAT);
    				return;
    			}
    		}
    		base.WndProc(ref m);
    	}
    }
