    using System;
    using System.ComponentModel;
    using System.Threading;
    void BackgroundWorkerTimerCancellation()
    {
        var worker = new BackgroundWorker { WorkerSupportsCancellation = true };
        // Cancellation support.
        var cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;
        // Cancel worker when the CancellationTokenSource is canceled.
        cancellationToken.Register(worker.CancelAsync);
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
                        // Wire cancellation.
                        cancellationToken.Register(() =>
                        {
                            // Cancel the timer (callback will never execute).
                            timer.Change(Timeout.Infinite, Timeout.Infinite);
                            // Signal wait handle immediately when canceled.
                            // It's lack of this call which is making
                            // your BackgroundWorker run indefinitely
                            // when the timer is canceled.
                            innerMRE.Set();
                        });
                        // Block until timer callback runs or until
                        // the CancellationTokenSource is canceled.
                        innerMRE.WaitOne();
                    }
                }
                outerMRE.Set(); // Allow test to complete.
            };
            // Start the worker (non-blocking).
            worker.RunWorkerAsync();
            // Schedule auto-cancellation after 1 second (non-blocking).
            cts.CancelAfter(TimeSpan.FromSeconds(1));
            // Block until all done.
            // Will take 10 seconds without cancellation,
            // or one second with cancellation.
            outerMRE.WaitOne();
        }
    }
