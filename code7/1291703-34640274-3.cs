	Process[] ps = Process.GetProcessesByName("chrome");
	DateTime start = DateTime.Now;
	for (int i = 0 ; i < 1000 ; i++) {
		ps.Where(p => p.StartTime < DateTime.Now).ToList();
	}
	TimeSpan duratiom = DateTime.Now - start;
