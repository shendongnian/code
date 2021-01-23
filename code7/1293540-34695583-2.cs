    [HandleProcessCorruptedStateExceptions]
    public static void SetupUnobservedTaskExceptionHandling(ILogger logger)
    {
        logger.Debug("Setting up unobserved task exception handling...");
        TaskScheduler.UnobservedTaskException += (sender, args) =>
        {
            var e = args.Exception;
            logger.ErrorFormat("TaskScheduler Unobserved Exception - Message: {0}", e.Message);
            logger.ErrorFormat("TaskScheduler Unobserved Exception - Inner exception: {0}", e.InnerException);
            logger.ErrorFormat("TaskScheduler Unobserved Exception - Inner exceptions: {0}", e.InnerExceptions);
            logger.ErrorFormat("TaskScheduler Unobserved Exception - StackTrace: {0}", e.StackTrace);
            args.SetObserved();
        };
    }
