    if (BackTestCollection.Any(bt => bt.TestStatus == TestStatus.Running))
    {
        bool done = false;
        // Update running test.
        Task.Run(async () =>
        {
            StatusMessage = "Stopping running backtest...";
            await SaveBackTestEventsAsync(SelectedBackTest);
            Log.Trace(String.Format(
                "Shutdown requested: saved backtest \"{0}\" with events",
                SelectedBackTest.Name));
    
            this.source = new CancellationTokenSource();
            this.token = this.source.Token;
            var filter = Builders<BsonDocument>.Filter.Eq(
                BackTestFields.ID, DocIdSerializer.Write(SelectedBackTest.Id));
            var update = Builders<BsonDocument>.Update.Set(BackTestFields.STATUS, TestStatus.Cancelled);
            IMongoDatabase database = client.GetDatabase(Constants.DatabaseMappings[Database.Backtests]);
            await MongoDataService.UpdateAsync<BsonDocument>(
                database, Constants.Backtests, filter, update, token);
            Log.Trace(String.Format(
                "Shutdown requested: updated backtest \"{0}\" status to \"Cancelled\"",
                SelectedBackTest.Name));
            StatusMessage = "Disposing backtest engine...";
            if (engine != null)
                engine.Dispose();
            Log.Trace("Shutdown requested: disposed backtest engine successfully");
            callback(true);
            done = true;
        });
        while (!done)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                                    new Action(delegate { }));
        }
    }
