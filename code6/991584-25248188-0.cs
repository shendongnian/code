        public async Task DoWork(Action action)
        {
            try
            {
                _task = await Task.Factory.StartNew(action);
            }
            catch (AggregateException ex)
            {
                // Log exceptions
                foreach (var innerEx in ex.InnerExceptions)
                {
                    Logger.Log(innerEx);
                }
            }
        }
    And then change `DoWork` to return `Task`:
        public static Task Run(Action action)
        {
            return new IISBackgroundTask().DoWork(action);
        }
