        for (int i = 0; i < 100; ++i)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(new Action(delegate()
            {
                mProgress.Value += 1.0;
                // Only sleeping to artificially simulate a long running operation
                Thread.Sleep(100);
            }), DispatcherPriority.Background);
        }
