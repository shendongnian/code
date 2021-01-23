    public async Task StartManager()
    {
        foreach (var reportGeneratorThread in this.ReportGenerators)
        {                
            reportGeneratorThread.Start();
        }
        while (true)
        {
            try
            { 
                Task task = await Task.WhenAny(this.Tasks.ToArray());
                if (task.IsFaulted)
                {
                    // Unpack the exception. Alternatively, you could just retrieve the
                    // AggregateException directly from task.Exception and process it
                    // exactly as in the original code (i.e. enumerate the
                    // AggregateException.InnerExceptions collection). Note that in
                    // that case, you will see only a single exception in the
                    // InnerExceptions collection. To detect exceptions in additional
                    // tasks, you would need to await them as well. Fortunately,
                    // this will happen each time you loop back and call Task.WhenAny()
                    // again, since all the tasks are in the Tasks collection being
                    // passed to WhenAny().
                    await task;
                }
            }
            catch (Exception v)
            {
                var taskException = v as TaskCanceledException;
                if (v != taskException)
                {
                    foreach (var reportGenerator in this.ReportGenerators)
                    {
                        if (reportGenerator.Task.IsFaulted)
                        {
                            this.logger.LogEvent(this.Id.ToString(), string.Format(CultureInfo.InvariantCulture, "System"), string.Format(CultureInfo.InvariantCulture, "Unhandled exception from Task " + reportGenerator.Task.Id));                             
                            ReportGeneratorThread faultedReportGeneratorThread = this.GetThreadById(reportGenerator.Task.Id);
                            var index = this.ReportGenerators.FindIndex(t => t.Equals(faultedReportGeneratorThread));
                            this.DisposeFaultedThread(faultedReportGeneratorThread, index);                           
                            this.ReportGenerators[index].Start();    
                            this.logger.LogDebug(string.Format(CultureInfo.InvariantCulture, "Faulted Task, and instance of ReportGeneratorThread is recreated and corresponding task is started"));
                            break;
                        }
                    }
                }
                else
                {
                    this.logger.LogEvent(this.Id.ToString(), string.Format(CultureInfo.InvariantCulture, "System"), string.Format(CultureInfo.InvariantCulture, "Task " + taskException.Task.Id + " has thrown a Task Canceled Exception"));
                    // Cancelling tasks...time to exit
                    return;
                }
            }
        }    
    }
