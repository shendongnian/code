	static void Main() {
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		if (!System.Diagnostics.Debugger.IsAttached) {
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
			AppDomain.CurrentDomain.UnhandledException += LogUnhandledExceptions;
		}
		Application.Run(new T5ShortestTimeForm());
	}
	private static void LogUnhandledExceptions(object sender, UnhandledExceptionEventArgs e) {
		Exception ex = (Exception)e.ExceptionObject;
		string errordir = Path.Combine(Application.StartupPath, "errorlog");
		string errorlog = Path.Combine(errordir, DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + ".txt");
		if (!Directory.Exists(errordir))
			Directory.CreateDirectory(errordir);
		File.WriteAllText(errorlog, ex.ToString());
		Environment.Exit(System.Runtime.InteropServices.Marshal.GetHRForException(ex));
	}
