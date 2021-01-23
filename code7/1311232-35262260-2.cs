	private static System.Object lockThis = new System.Object();
	public static ConsoleColor oldColor = Console.ForegroundColor;
	private static int seed = Environment.TickCount;
	private static readonly ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));
	
	static void Main(string[] args)
	{
		var x = GetValue("How Many Die Would You Like To Roll?", 1);
		if (x.HasValue)
		{
			var y = GetValue("How Many Sides Do You Want Each Die To Have?", 2);
			if (y.HasValue)
			{
				int numberOfDie = x.Value;
				int numberOfSides = y.Value;
				double percent = 100 * Math.Pow(1.0 / numberOfSides, numberOfDie);
	
				Console.WriteLine("With " + numberOfDie + ", " + numberOfSides + " Sided Die, You Have An " + percent + '%' + " Chance of Getting A Yahtzee With Any Given Roll");
	
				Console.WriteLine("Press Any Key To Commence");
				Console.ReadLine();
	
				int processorCount = System.Math.Min(Environment.ProcessorCount, 8);
				Console.WriteLine(processorCount);
	
				CancellationTokenSource[] ctss =
					Enumerable
						.Range(1, processorCount)
						.Select(n =>
						{
							var cts = new CancellationTokenSource();
							var t = new Thread(() =>
								Rolling(n, numberOfDie, numberOfSides, percent, cts.Token));
							t.Start();
							return cts;
						})
						.ToArray();
	
				while (true)
				{
					string quit = Console.ReadLine().Substring(0, 1).ToUpper();
					if (quit == "Q")
					{
						Console.WriteLine(Environment.NewLine, "Terminated");
						break;
					}
				}
	
				foreach (var cts in ctss)
				{
					cts.Cancel();
				}
			}
		}
	}
	
	private static int? GetValue(string prompt, int minimum)
	{
		while (true)
		{
			Console.WriteLine(prompt + " Type Q To Quit");
			var input = Console.ReadLine().Substring(0, 1).ToUpper();
			if (input == "Q")
			{
				return null;
			}
			int output;
			if (int.TryParse(input, out output))
			{
				if (output < minimum)
				{
					Console.WriteLine("Please Enter an Integer Greater Than Or Equal To " + minimum);
					continue;
				}
				else
				{
					return output;
				}
			}
		}
	}
	
	private static void Rolling(int n, int numberOfDie, int numberOfSides, double percent, CancellationToken ct)
	{
		Console.WriteLine("Thread" + n + " Started");
	
		Stopwatch rollTime = Stopwatch.StartNew();
	
		long numberOfRolls = 0;
		while (true)
		{
			if (ct.IsCancellationRequested)
			{
				Console.WriteLine("Done with thread " + n);
				break;
			}
	
			int[] valuesOfRoll =
				Enumerable
					.Range(0, numberOfDie)
					.Select(x => random.Value.Next(numberOfSides) + 1)
					.ToArray();
	
			Boolean isItYahtzee = valuesOfRoll.All(x => x == valuesOfRoll[0]);
	
			if ((numberOfRolls++ % 100000000) == 0)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Thread" + n + " has rolled " + numberOfRolls);
				Console.ForegroundColor = oldColor;
			}
	
			if (isItYahtzee == true)
			{
				rollTime.Stop();
				string time = rollTime.Elapsed.ToString();
				string timeSec = rollTime.Elapsed.TotalSeconds.ToString();
				string linesA =
					String.Format(
						"{0},{1},{2},{3},{4}%,{5},{6},{7},{8}",
						numberOfDie,
						numberOfSides,
						numberOfDie * numberOfSides,
						numberOfRolls,
						percent,
						percent * numberOfRolls,
						time,
						timeSec,
						numberOfRolls / rollTime.Elapsed.TotalSeconds);
				string linesB = (numberOfRolls).ToString();
				lock (lockThis)
				{
					File.AppendAllLines(Directory.GetCurrentDirectory() + "\\All.txt", new[] { linesA });
					File.AppendAllLines(Directory.GetCurrentDirectory() + "\\Avg_" + numberOfDie + "X" + numberOfSides + ".txt", new[] { linesB });
				}
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(numberOfRolls + " File Has Been Successfully Save By Thread " + n);
				Console.ForegroundColor = oldColor;
				numberOfRolls = 0;
				break;
			}
		}
	}
