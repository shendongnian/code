            [TaskName("loglevel")]
			public class LogLevelTask : TaskContainer
			{
				private Level _logLevel;
				
				protected override void ExecuteTask()
				{
					Level oldLevel = Project.Threshold;
					try
					{
						SetLogLevel(_logLevel);
						base.ExecuteTask();
					}
					finally
					{
						SetLogLevel(oldLevel);
					}
				}
				
				[TaskAttribute("level", Required = true)]
				public Level LogLevel
				{
					get
					{
						return _logLevel;
					}
					set
					{
						_logLevel = value;
					}
				}
				
				public void SetLogLevel(Level newLevel)
				{
					foreach(IBuildListener listener in Project.BuildListeners)
					{
						IBuildLogger logger = listener as IBuildLogger;
						if(logger != null)
						{
							logger.Threshold = newLevel;
						}
					}
				}
			}
