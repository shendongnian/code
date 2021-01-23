    public void StopServiceAndWaitForExit()
		{
			using (var controller = new ServiceController(nameOfService, nameOfServerWithService))
			{
				var ssp = new SERVICE_STATUS_PROCESS();
				int ignored;
				if (!QueryServiceStatusEx(controller.ServiceHandle.DangerousGetHandle(), SC_STATUS_PROCESS_INFO, ref ssp, Marshal.SizeOf(ssp), out ignored))
					throw new Exception("Couldn't obtain service process information.");
				if (ssp.dwServiceType != SERVICE_WIN32_OWN_PROCESS)
					throw new Exception("Can't wait for the service's hosting process to exit because there may be multiple services in the process (dwServiceType is not SERVICE_WIN32_OWN_PROCESS");
				if ((ssp.dwServiceFlags & SERVICE_RUNS_IN_SYSTEM_PROCESS) != 0)
					throw new Exception("Can't wait for the service's hosting process to exit because the hosting process is a critical system process that will not exit (SERVICE_RUNS_IN_SYSTEM_PROCESS flag set)");
				if (ssp.dwProcessId == 0)
					throw new Exception("Can't wait for the service's hosting process to exit because the process ID is not known.");
				using (Process process = Process.GetProcessById(ssp.dwProcessId, nameOfServerWithService))
				{
					var threadData = new ProcessWaitForExitData();
					threadData.Process = process;
					var processWaitForExitThread = new Thread(ProcessWaitForExitThreadProc);
					processWaitForExitThread.IsBackground = Thread.CurrentThread.IsBackground;
					processWaitForExitThread.Start(threadData);
					controller.Stop();
					lock (threadData.Sync)
						while (!threadData.HasExited)
							Monitor.Wait(threadData.Sync);
				}
			}
		}
