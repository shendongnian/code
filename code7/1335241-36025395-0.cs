	tickerStart = System.Environment.TickCount;
	do
	{
		numbers.AddText(Convert.ToString(number), 100);
	}
	while (System.Environment.TickCount - tickerStart < 5000);
	
	numbers.AddRectangle(0, 0, 800, 600, Color.Black);
