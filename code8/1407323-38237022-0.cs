	/// <summary>Defines what versions of Task Scheduler or the AT command that the task is compatible with.</summary>
	public enum TaskCompatibility
	{
		/// <summary>The task is compatible with the AT command.</summary>
		AT,
		/// <summary>The task is compatible with Task Scheduler 1.0 (Windows Server™ 2003, Windows® XP, or Windows® 2000).</summary>
		V1,
		/// <summary>The task is compatible with Task Scheduler 2.0 (Windows Vista™, Windows Server™ 2008).</summary>
		V2,
		/// <summary>The task is compatible with Task Scheduler 2.1 (Windows® 7, Windows Server™ 2008 R2).</summary>
		V2_1,
		/// <summary>The task is compatible with Task Scheduler 2.2 (Windows® 8.x, Windows Server™ 2012).</summary>
		V2_2,
		/// <summary>The task is compatible with Task Scheduler 2.3 (Windows® 10, Windows Server™ 2016).</summary>
		V2_3,
	}
