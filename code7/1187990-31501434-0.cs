	int currentposition = 0;
	var setting = ArrayTest.Properties.Settings.Default.mapSaveSetting;
	
	for (int x = 0; x < 100; x++)
	{
		for (int y = 0; y < 100; y++)
		{
			map[x, y] = int.Parse(setting[currentposition].ToString());
			currentposition++;
		}
	}
	
