    public class RfidReaderHardware {
        public event EventHandler Received;
        public RfidReaderHardware() {
            syncContext = System.Threading.SynchronizationContext.Current;
        }
        protected void OnReceived(EventArgs e) {
            if (syncContext == null) FireReceived(e);
            else syncContext.Send((_) => FireReceived(e), null);
        }
        protected void FireReceived(EventArgs e) {
            var handler = Received;
            if (handler != null) Received(this, e);
        }
        private System.Threading.SynchronizationContext syncContext;
    }
