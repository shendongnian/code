    public class WindowThatDisplaysTheLog : Form {
        public WindowThatDisplaysTheLog() { 
            InitializeComponent(); 
            log = new Log();
            log.NewLogEntryAdded += UpdateLogDataGridView;
        }
        private void UpdateLogDataGridView(object sender, EventArgs e) {
            // Reload your Log entries from the underlying database.
            // You now shall see the LogDataGridView updating itself 
            // whenever a new log entry is inserted.
        }
        
        private Log log;
    }
