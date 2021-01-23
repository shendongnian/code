    public class Log {
        public void UpdateLog(string description) {
            // insert the new Log line into your database.
            if (thereIsAtLeastOneNewLogEntryAddedSubscriber())
                raiseTheNewLogEntryAddedEvent();
        }
        public event EventHandler NewLogEntryAdded;
        private raiseTheNewLogEntryAddedEvent() {
            NewLogEntryAdded(this, EventArgs.Empty);
        }
        private bool thereIsAtLeastOneNewLogEntryAddedSubscriber() {
            return NewLogEntryAdded != null;
        }
    }
