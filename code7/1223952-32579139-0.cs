        /// <summary>Reconfigures the measurement delayed so two calls short after each other only trigger one reconfiguration.</summary>
    public void ReconfigureMeasurementDelayed()
    {
        lock (reconfigurationLock)
        {
            if (reconfigurationScheduled)
                return;
            reconfigurationScheduled = true;
        }
        Task.Run(() =>
            {                                
                ReconfigureMeasurement();
                lock (reconfigurationLock) {
                     reconfigurationScheduled = false;
                }
            });
    }
