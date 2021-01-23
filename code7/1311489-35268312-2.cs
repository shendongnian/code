    // This method handles all ceremony around the real work of this service.
    private async Task LaunchWorkAsync()
    {
        try 
        {
            // Setup progress reporting.
            var progressReport = new Progress<string>
                    (progressInfo => { this.AppLog.Information(progressInfo, "ServiceMain.LaunchWorkAsync"); });
            var progress = progressReport as IProgress<string>;
            // Launch time.
            await Task.Factory.StartNew( () => this.DoWork(progress), TaskCreationOptions.LongRunning );
        }
        // Report any exception raised during the work cycle.
        catch (Exception ex)
        {
            this.AppLog.Error(string.Concat("Work cycle crashed", Environment.NewLine,
                                             ex.GetType().FullName, Environment.NewLine,
                                             ex.Message, Environment.NewLine,
                                             ex.StackTrace));
        }
        return;
    }
