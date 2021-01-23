        void CatchUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            _log.Fatal("The service threw an unhandled exception", (Exception)e.ExceptionObject);
            HostLogger.Shutdown();
            if (e.IsTerminating)
            {
                _exitCode = TopshelfExitCode.UnhandledServiceException;
                _exit.Set();
    #if !NET35
                // it isn't likely that a TPL thread should land here, but if it does let's no block it
                if (Task.CurrentId.HasValue)
                {
                    return;
                }
    #endif
                // this is evil, but perhaps a good thing to let us clean up properly.
                int deadThreadId = Interlocked.Increment(ref _deadThread);
                Thread.CurrentThread.IsBackground = true;
                Thread.CurrentThread.Name = "Unhandled Exception " + deadThreadId.ToString();
                while (true)
                    Thread.Sleep(TimeSpan.FromHours(1));
            }
        }
