        private bool _running = true;
        private int _workCounter = 0;
        private AutoResetEvent _workFlag = new AutoResetEvent(false);
        private void RunNoGCNativeCode(params object[] args)
        {
            // Increase the work counter to determine how many requests are being processed
            if (Interlocked.Increment(ref _workCounter) == 1)
            {
                // Try to start a No GC Region
                GC.TryStartNoGCRegion(1 * 1024 * 1024 * 1024, true);
            }
            // TODO: Prep data and execute your native code
            // TODO: Process response
            // TODO: Dispose of anything that is no longer in use and null objects as needed
            if (Interlocked.Decrement(ref _workCounter) == 0 && GCSettings.LatencyMode == GCLatencyMode.NoGCRegion)
            {
                GC.EndNoGCRegion();
            }
            // Notify Manual Collection thread work has been completed
            _workFlag.Set();
        }
