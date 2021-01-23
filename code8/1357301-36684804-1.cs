	IEnumerable<int> listOfThings = new List<int>();
	logBox.GetTimeLapse();
	for (int i = 0; i < 10000000; ++i)
		foreach (var thing in listOfThings)
			Console.WriteLine("Do something!");
	logBox.WriteTimedLogLine("Without Any: " + logBox.GetTimeLapse());
	logBox.GetTimeLapse();
	for (int i = 0; i < 10000000; ++i)
		if (listOfThings.Any())
			foreach (var thing in listOfThings)
				Console.WriteLine("Do something!");
	logBox.WriteTimedLogLine("With Any: " + logBox.GetTimeLapse());
