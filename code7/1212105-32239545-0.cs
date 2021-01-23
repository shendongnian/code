	int readLimit = 10;
	int delayBetweenRead = 20;
	int globalDelay = 30;
	int linesRead = 100;
	
	var subscription =
		Observable
			.Generate(0, n => n < linesRead, n => n + 1, n => n,
				n => TimeSpan.FromSeconds(n % readLimit == 0 ? globalDelay : delayBetweenRead))
			.Zip(System.IO.File.ReadLines(ofd.FileName), (n, line) => line)
			.Subscribe(line =>
			{
				/* do something with each line */
			});
