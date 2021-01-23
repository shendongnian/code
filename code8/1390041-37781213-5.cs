    // Send a your array of names to the Sharknadoo application.
    public void sendToSharknadoo(String[] detailsToSend)
    {
        // Get a handle to the Sharknadoo application. The window class
        // and window name can be obtained from Sharknadoo using the
        // Spy++ tool.
        IntPtr windowHandle = FindWindow("SharknadooFrame","Sharknadoo");
        // Verify that Sharknadoo is a running process.
        if (windowHandle == IntPtr.Zero)
        {
            MessageBox.Show("Sharknadoo is not running.");
            return;
        }
        // Make Sharknadoo the foreground application and set the number 
        // of text boxes for your info
        SetForegroundWindow(windowHandle);
        // Get to first box
		SendKeys.SendWait("{TAB}");
		// enter number of boxes
		SendKeys.SendWait("{DOWN}");
		SendKeys.SendWait((string)detailsToSend.Length);
			
		// Now enter your details into each of those boxes
		foreach (String s in detailsToSend)
		{
			// Get next textbox box
			SendKeys.SendWait("{TAB}");
               SendKeys.SendWait(s);
		}
    }
