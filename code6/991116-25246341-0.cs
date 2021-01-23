    DateTime portEntry = DateTime.MinValue;
	bool isValidDateTime = DateTime.TryParseExact(null, "dd/MM/yyyy HH:mm:ss.fff", enUS, DateTimeStyles.None, out portEntry);
    if (!isValidDateTime)
    {
        // throw? log? ignore?
    }
