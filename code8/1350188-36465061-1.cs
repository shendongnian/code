	TimeZoneInfo PST = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
	TimeZoneInfo EST = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
	DateTimeOffset t0 = DateTimeOffset.UtcNow;
	DateTimeOffset t0p = TimeZoneInfo.ConvertTime(t0, PST);
	DateTimeOffset t0e = TimeZoneInfo.ConvertTime(t0, EST);
	Thread.Sleep(100);
	DateTimeOffset t1 = DateTimeOffset.UtcNow;
	DateTimeOffset t1p = TimeZoneInfo.ConvertTime(t1, PST);
	DateTimeOffset t1e = TimeZoneInfo.ConvertTime(t1, EST);
	Assert.AreEqual(t1, t0.OrIfLater(t1));
	Assert.AreEqual(t1p, t0p.OrIfLater(t1p));
	Assert.AreEqual(t1e, t1e.OrIfLater(t1p));
	Assert.AreEqual(t1e, t0p.OrIfLater(t1e));
	Assert.IsTrue(t1p > t0e);
	Assert.IsTrue(t1p.Ticks > t0e.Ticks); //still fails
	Assert.AreEqual(t1p, t1p.OrIfLater(t0e));
