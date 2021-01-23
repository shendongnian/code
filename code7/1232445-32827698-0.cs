    void BlockingMethod() {
        Task.Factory.StartNew(() => {
            // blocking work here, db loading for example
        })
        .ContinueWith(result => {
    		// update control here with the result of result.Result
           },
           TaskScheduler.FromCurrentSynchronizationContext()
        });
    }
