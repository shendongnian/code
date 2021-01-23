    protected override void WndProc(ref Message m)
    {
    	if (m.Msg == WM_HOTKEY)
    	{
    		var param = (int)m.WParam;
    		switch (param)
    		{
    			case 1:
    				Console.WriteLine("w");
    				break;
    			case 2:
    				Console.WriteLine("a");
    				break;
    			case 3:
    				Console.WriteLine("s");
    				break;
    			case 4:
    				Console.WriteLine("d");
    				break;
    			default:
    				Console.WriteLine("Unrecognised key stroke.");
    		}
    		base.WndProc(ref m);
    	}
    	// todo:  What if m.Msg is no WM_HOTKEY?
    }
