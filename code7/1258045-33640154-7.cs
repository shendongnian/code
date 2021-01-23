    using WUApiLib;
    public static IEnumerable<IUpdateHistoryEntry> GetAllUpdates(string machineName)
    {
		Type t = Type.GetTypeFromProgID("Microsoft.Update.Session", machineName);
		UpdateSession session = (UpdateSession)Activator.CreateInstance(t);
		IUpdateSearcher updateSearcher = session.CreateUpdateSearcher();
		int count = updateSearcher.GetTotalHistoryCount();
		IUpdateHistoryEntryCollection history = updateSearcher.QueryHistory(0, count);
		return history.Cast<IUpdateHistoryEntry>();
    }
    public static DateTime GetLastSuccessfulUpdateTime(string machineName)
    {
        DateTime lastUpdate = DateTime.Parse("0001-01-01 00:00:01");
		var updates = GetAllUpdates(machineName);
		if (updates.Where(u => u.HResult == 0).Count() > 0)
		{
			lastUpdate = updates.Where(u => u.HResult == 0).OrderBy(x => x.Date).Last().Date;
		}
        return lastUpdate;
    }
