    public void Should_WriteTheCorrectLogEntries_WhenTasksAreExecutedAndNotCancelled()
    {
        // Defines the task that needs to be executed.
        var task = new LongRunningServiceTaskImplementation();
        // USE THE CLASS I PROPOSE:
        var tracker = new SequenceTracker();
        //LoggerMock.Setup(x => x.Information(It.IsAny<string>(), It.IsAny<string>()))
        LoggerMock.Setup(x => x.Information("émqsdlfk", "smdlfksdmlfk"))
            .Callback(() => tracker.Next(10));
        LoggerMock.Setup(x => x.Information(LoggingResources.LoggerTitle, LoggingResources.Logger_ServiceStopped))
            .Callback(() => tracker.Next(20));
        LoggerMock.Setup(x => x.Information(LoggingResources.LoggerTitle, LoggingResources.Logger_ServiceStarted))
            .Callback(() => tracker.Next(30));
        LoggerMock.Setup(x => x.Information(LoggingResources.LoggerTitle, string.Format(CultureInfo.InvariantCulture, LoggingResources.Logger_TaskCompleted, task.TaskName)))
            .Callback(() => tracker.Next(40));
        LoggerMock.Setup(x => x.Information(LoggingResources.LoggerTitle, LoggingResources.Logger_ServiceStopped))
            .Callback(() => tracker.Next(50));
        // Setup the mock required for the tests.
        TaskGathererMock.Setup(x => x.GetServiceTasks(LoggerMock.Object)).Returns(() =>
        {
            return new[] { task };
        });
        // Start the scheduler.
        Scheduler.Start(TaskGathererMock.Object, ConfigurationManagerMock.Object);
        // Wait for 5 seconds (this simulates running the service for 5 seconds).
        // Since our tasks execution time takes 4 seconds, all the assigned tasks should have been completed.
        Thread.Sleep(5000);
        // Stop the service. (We assume that all the tasks have been completed).
        Scheduler.Stop();
        // THIS NOW WORKS BECAUSE WE ABANDONED THE 'MockSequence' APPROACH:
        LoggerMock.VerifyAll();
    }
