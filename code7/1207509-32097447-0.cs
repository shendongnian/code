	class ExitEventListener : IDebugEventCallback2
	{
		private IVsDebugger _debugger;
	
		public ExitEventListener()
		{
			_debugger = Package.GetGlobalService(typeof(SVsShellDebugger)) as IVsDebugger;
			if (_debugger != null)
				_debugger.AdviseDebugEventCallback(this);
		}
	
		public int Event(IDebugEngine2 pEngine, IDebugProcess2 pProcess, IDebugProgram2 pProgram, IDebugThread2 pThread, IDebugEvent2 pEvent, ref Guid riidEvent, uint dwAttrib)
		{
			if (pEvent is IDebugProgramDestroyEvent2)
			{
				// The process has exited
			
				uint exitCode;
				if (((IDebugProgramDestroyEvent2)pEvent).GetExitCode(out exitCode) == VSConstants.S_OK)
				{
					// We got the exit code!
				}
				
				// Stop listening for future exit events
				_debugger.UnadviseDebugEventCallback(this);
				_debugger = null;
			}
			return VSConstants.S_OK;
		}
	}
