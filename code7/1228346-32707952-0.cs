	public static class CrashHandler
	{
		public static bool Initialized { get; private set; }
		[SecurityPermission(SecurityAction.Demand, Flags=SecurityPermissionFlag.ControlAppDomain)]
		static CrashHandler()
		{
			AppDomain.CurrentDomain.UnhandleException += crash_handler;
			Initialized = true;
		}
		static void crash_handler(object sender, UnhandledExceptionEventArgs args)
		{
			// do your thing here
		}
	}
