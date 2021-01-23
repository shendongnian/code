    				var logger = new FilteredLogger((ILogger)new RichConsoleLogger(webConsole), Verbosity.Normal);
					var setup = new RuntimeSetup();
					setup.AddPluginDirectory(@"C:\Program Files (x86)\Gallio\bin");
					if (!RuntimeAccessor.IsInitialized) {
						RuntimeBootstrap.Initialize(setup, logger);
					}
				
					var progressMonitorProvider = new RichConsoleProgressMonitorProvider(webConsole);
					var launcher = new TestLauncher { Logger = logger, ProgressMonitorProvider = progressMonitorProvider, RuntimeSetup = setup, EchoResults = true };
					launcher.TestProject.TestRunnerFactoryName = StandardTestRunnerFactoryNames.Local; 
					launcher.AddFilePattern(@"\path\to\Tests.dll");
					var testLauncherResult = launcher.Run();
					webConsole.WriteLine(testLauncherResult.ResultSummary);
