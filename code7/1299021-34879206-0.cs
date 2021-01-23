    // Create a new Mutex. The creating thread does not own the mutex.
    private static Mutex mux = new Mutex();
    private void tmrAPACSEvent_Elapsed(object sender, ElapsedEventArgs e)
    {
        Library.WriteErrorLog("tmrAPACSEvent ticked and some job has been done successfully");
        try
        {
            var UnProcessedEvents = BLCustomService.GetCustomEvents();
            if (UnProcessedEvents != null)
            {
                tmrAPACSEvent.Enabled = false;
                // Wait until it is safe to enter, and do not enter if the request times out.
                if (mux.WaitOne(7000))
                {
                    // do work
                    // note this is inside the mutex so that the timer is guaranteed enabled, even for just a moment
                    tmrAPACSEvent.Enabled = true;
                }
            }
        }
        catch (Exception exception)
        {
            Library.WriteErrorLog("Error 96: " + exception.StackTrace);
        }
    }
