        public TopshelfExitCode Run()
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            AppDomain.CurrentDomain.UnhandledException += CatchUnhandledException;
            if (_environment.IsServiceInstalled(_settings.ServiceName))
            {
                if (!_environment.IsServiceStopped(_settings.ServiceName))
                {
                    _log.ErrorFormat("The {0} service is running and must be stopped before running via the console",
                        _settings.ServiceName);
                    return TopshelfExitCode.ServiceAlreadyRunning;
                }
            }
            bool started = false;
            try
            {
                _log.Debug("Starting up as a console application");
                _log.Debug("Thread.CurrentThread.Name");
                _log.Debug(Thread.CurrentThread.Name);
                _exit = new ManualResetEvent(false);
                _exitCode = TopshelfExitCode.Ok;
                Console.Title = _settings.DisplayName;
                Console.CancelKeyPress += HandleCancelKeyPress;
                if (!_serviceHandle.Start(this))
                    throw new TopshelfException("The service failed to start (return false).");
                started = true;
                _log.InfoFormat("The {0} service is now running, press Control+C to exit.", _settings.ServiceName);
                _exit.WaitOne();
            }
            catch (Exception ex)
            {
                _log.Error("An exception occurred", ex);
                return TopshelfExitCode.AbnormalExit;
            }
            finally
            {
                if (started)
                    StopService();
                _exit.Close();
                (_exit as IDisposable).Dispose();
                HostLogger.Shutdown();
            }
            return _exitCode;
        }
