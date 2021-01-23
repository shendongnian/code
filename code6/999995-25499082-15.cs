	int statusLine = -1;
	for (int i = 0; i < 10; i++)
	{
		Console.WriteLine("Other lines in here...");
	
		DoLongRunningOperation();
	
		//update the status line here
		SetTextForLine("Status " + i + " Copied", ref statusLine);
	}
