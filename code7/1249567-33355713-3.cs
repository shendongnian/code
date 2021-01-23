    public async Task StartManager()
    {
        foreach (var reportGeneratorThread in this.ReportGenerators)
        {                
            reportGeneratorThread.Start();
            Thread.Sleep(1000);
        }
    
        try
        { 
            await Task.WhenAll(this.Tasks.ToArray());
        }
        catch (AggregateException e)
        {
            foreach (var v in e.InnerExceptions)
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
                    else if (taskException != null)
                    {
                        this.logger.LogEvent(this.Id.ToString(), string.Format(CultureInfo.InvariantCulture, "System"), string.Format(CultureInfo.InvariantCulture, "Task " + taskException.Task.Id + " has thrown a Task Canceled Exception"));
                    }
                }
        }
    }
