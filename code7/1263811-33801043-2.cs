	internal void ScheduleAndStart(bool needsProtection)
	{
		if (needsProtection)
		{
			if (!this.MarkStarted())
			{
				return;
			}
		}
		else
		{
			this.m_stateFlags |= 65536;
		}
		if (Task.s_asyncDebuggingEnabled)
		{
			Task.AddToActiveTasks(this);
		}
		if (AsyncCausalityTracer.LoggingOn && 
		   (this.Options & (TaskCreationOptions)512) == TaskCreationOptions.None)
		{
			AsyncCausalityTracer.TraceOperationCreation(
				CausalityTraceLevel.Required, this.Id, "Task: " +
				((Delegate)this.m_action).Method.Name, 0uL);
		}
		try
		{
			this.m_taskScheduler.InternalQueueTask(this);
		}
		catch (ThreadAbortException exceptionObject)
		{
			this.AddException(exceptionObject);
			this.FinishThreadAbortedTask(true, false);
		}
		catch (Exception arg_93_0)
		{
			TaskSchedulerException ex = new TaskSchedulerException(arg_93_0);
			this.AddException(ex);
			this.Finish(false);
			if ((this.Options & (TaskCreationOptions)512) == TaskCreationOptions.None)
			{
				this.m_contingentProperties.m_exceptionsHolder.MarkAsHandled(false);
			}
			throw ex;
		}
	}
