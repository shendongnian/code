    using System;
    using System.ComponentModel;
    using System.Threading;
    [TestMethod]
    public void BackgroundWorkerTimerCancellation()
    {
        var cts = new CancellationTokenSource();
        var worker = new BackgroundWorker { WorkerSupportsCancellation = true };
        var cancellationToken = cts.Token;
        cancellationToken.Register(worker.CancelAsync); // Cancel worker on cts.Cancel().
        // For testing.
        using (var outerMRE = new ManualResetEvent(false))
        {
            worker.DoWork += delegate
            {
                using (var innerMRE = new ManualResetEvent(false))
                {
                    // Our timer which takes a looong time.
                    using (var timer = new Timer(_ => innerMRE.Set(), null, 10000 /* 10 seconds */, Timeout.Infinite))
                    {
                        // Wire cancellation causing timer's callback
                        // to fire immediately on cts.Cancel().
                        cancellationToken.Register(() => timer.Change(0, Timeout.Infinite));
                        // Block until the timer callback runs.
                        innerMRE.WaitOne();
                    }
                }
                outerMRE.Set(); // Allow test to complete.
            };
            worker.RunWorkerAsync();
            // Schedule auto-cancellation after 1 second.
            cts.CancelAfter(TimeSpan.FromSeconds(1));
            // Block until all done.
            // Will take 10 seconds without cancellation,
            // or one second with cancellation.
            outerMRE.WaitOne();
        }
    }
