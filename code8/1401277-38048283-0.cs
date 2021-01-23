	var CurrentSampleRate = 30;
	Observable
		.Generate(0, x => true, x => x + 1, x => x, x => TimeSpan.FromMilliseconds(CurrentSampleRate))
		.Subscribe(x =>
		{
			if (x == 50)
			{
				CurrentSampleRate = 1000;
			}
			Console.Write(".");
		});
