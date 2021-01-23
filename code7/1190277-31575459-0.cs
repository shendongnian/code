            isBusy = true;
            Task.Factory.StartNew(() =>
                {
                    //do some code. It is a new thread
                }).ContinueWith((x) =>
                {
                    //do some code after previous task is done. This code runs in the UI thread
                    isBusy = false;
                }, TaskScheduler.FromCurrentSynchronizationContext());
