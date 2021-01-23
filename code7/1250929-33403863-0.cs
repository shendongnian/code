    protected override void OnStart(string[] args)
    {
        // Storing the returned Task in a variable is a hack
        // to suppresses the usual compiler warning.
        var _ = DoMigrationLoop();
    }
    private async Task DoMigrationLoop()
    {
        while (true)
        {
            await Task.Run(() => this.DoMigration());
            await Task.Delay(TimeSpan.FromHours(4));
        }
    }
