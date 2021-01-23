    public partial class MainWindow : Window {
        private DummyXmlParser _test = new DummyXmlParser();
        public MainWindow() {
            InitializeComponent();
            new Thread(() => {
                _test.StartParseInBackground();
                _test.WaitHandle.WaitOne();
            }) {
                IsBackground = true
            }.Start();
            _test.StartParseInBackground();
            // don't do this, will deadlock
            _test.WaitHandle.WaitOne();
        }
    }
    public class DummyXmlParser {
        public DummyXmlParser() {
            WaitHandle = new ManualResetEvent(false);
        }
        public void StartParseInBackground() {
            Task.Run(() => {
                Thread.Sleep(1000);
                // this gets dispatched to UI thread, but UI thread is blocked by waiting on WaitHandle - deadlock
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Application.Current.MainWindow.Title = "Running at UI";
                });
                WaitHandle.Set();
            });
        }
        public ManualResetEvent WaitHandle { get; private set; }
    }
