	int statusLine = -1;
	for (int i = 0; i < 10; i++)
	{
		if (i % 2 == 0)
		{
			Console.WriteLine("Other lines in here " + DateTime.Now);
		}
	
		DoLongRunningOperation();
	
		//update the status line here
		SetTextForLine("Status " + i + " Copied", ref statusLine);
	}
