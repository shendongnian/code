            IsBusy = true;
            Task<SomeResult>.Factory.StartNew(() =>
            {
                Criteria newCriteria = new Criteria();
                return ExecuteGetDataFromDB(newCriteria);
            }, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default)
            .ContinueWith(t =>
            {
                CriteriaCollection.Add(t.Result);
                IsBusy = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());
