    // synchronization primitive
    private readonly object syncRoot = new object();
    // the timer for 500 miliseconds delay
    private Timer notificator;
    
    // public function used for notification with delay
    public void NotifyAllDataUpdatedWithDelay() {
        // first, we need claim lock, because of accessing from multiple threads
        lock(this.syncRoot) {
            if (null == notificator) {
                // notification timer is lazy-loaded
                notificator = new Timer(500);
                notificator.Elapse += notificator_Elapsed;
            }
            if (false == notificator.Enabled) {
                // timer is not enabled (=no notification is in delay)
                // enabling = starting the timer
                notificator.Enabled = true;
            }
        }
    }
    private void notificator_Elapsed(object sender, ElapsedEventArgs e) {
        // first, we need claim lock, because of accessing from multiple threads
        lock(this.syncRoot) {
            // stop the notificator
            notificator.Enabled = false;
        }
        // notify clients
        Clients.Others.allDataUpdated();
    }
