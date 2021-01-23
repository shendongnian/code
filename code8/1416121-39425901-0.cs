    using System;
	using NLog;
	using System.ServiceProcess;
	public class DDXService : ServiceBase
	{
		protected static Logger logger = LogManager.GetCurrentClassLogger();
		protected static void Start<T>(string[] args) where T : DDXService, new()
		{
			if (System.Diagnostics.Debugger.IsAttached)
			{
				logger.Debug("Running in DEBUG mode");
				(new T()).OnStart(new string[1]);
				ServiceBase.Run(new T());
			}
			else
			{
				logger.Debug("Running in RELEASE mode");
				ServiceBase[] ServicesToRun;
				ServicesToRun = new ServiceBase[] { new T() };
				ServiceBase.Run(ServicesToRun);
			} //if-else
		}
	}
