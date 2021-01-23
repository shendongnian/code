    		//Close Driver
		driver.Close();
		
		// Get the current process.
		System.Diagnostics.Process myProcess = System.Diagnostics.Process.GetCurrentProcess(); 
		// Close process by sending a close message to its main window.
		myProcess.CloseMainWindow();
		// Free resources associated with process.
		myProcess.Close();
		
		Environment.Exit(0);
