	for (int x = 0; x < rawLine.Length; x++)
	{
		string[] tempLine = rawLine[x].Split(';');
		for (int y = 0; y < tempLine.Length; y++)
		{
			DateTime hour = Convert.ToDateTime(tempLine[6]);
			for(int z=0; z<11; z++)
			{
				xlWorkSheet.Cells[y + 2, (z+1)] = tempLine[z];
			}
			xlWorkSheet.Cells[y + 2, 12] = hour.Hour;
			xlWorkSheet.Cells[y + 2, 13] = tempLine[8] == "0" ? "SAME" : tempLine[9];
		}
		Console.WriteLine("Current line = " + x + "\n");
	}
