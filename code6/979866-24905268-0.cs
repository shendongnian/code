	long ticks = DateTime.Ticks;
	while(DateTime.Ticks - ticks < 50000000) // 5 seconds
	{
		ReaderAPI.Actions.Inventory.Perform(null, null, antennainfo);
	}
	ReaderAPI.Actions.Inventory.Stop();
