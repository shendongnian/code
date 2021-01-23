	private static object _ratesFileLock = new object();
	public void UpdateRates()
	{
		Attempt(TryToUpdateRates, maximumNumberOfAttempts: 50, timeToWaitBetweenRetriesInMs: 100);
	}
	private void TryToUpdateRates()
	{
		lock (_ratesFileLock)
		{
			using (var stream = GetRatesFileStream())
			{
				var rates = LoadRatesFile(stream);
				// Apply any other update logic here
				WriteRatesToFile(rates, stream);
			}
		}
	}
	private Stream GetRatesFileStream()
	{
		return File.Open("rates.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
	}
	private IEnumerable<Rate> LoadRatesFile(Stream stream)
	{
		// Apply any other logic here
		return RatesSerialiser.Deserialise(stream);
	}
	private void WriteRatesToFile(IEnumerable<Rate> rates, Stream stream)
	{
		RatesSerialiser.Serialise(rates, stream);
	}
	private static void Attempt(Action work, int maximumNumberOfAttempts, int timeToWaitBetweenRetriesInMs)
	{
		var numberOfFailedAttempts = 0;
		while (true)
		{
			try
			{
				work();
				return;
			}
			catch
			{
				numberOfFailedAttempts++;
				if (numberOfFailedAttempts >= maximumNumberOfAttempts)
					throw;
				Thread.Sleep(timeToWaitBetweenRetriesInMs);
			}
		}
	}
