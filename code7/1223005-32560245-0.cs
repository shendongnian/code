    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            var console = new MyConsole();
            this.Content = console.Gui;
            Task.Factory.StartNew(() => {
                var read = console.ReadLine();
                console.WriteLine(read);
            });
        }
    }
    public class MyConsole {
        private readonly ManualResetEvent _readLineSignal;
        private string _lastLine;        
        public MyConsole() {
            _readLineSignal = new ManualResetEvent(false);
            Gui = new TextBox();
            Gui.AcceptsReturn = true;
            Gui.KeyUp += OnKeyUp;
        }
        private void OnKeyUp(object sender, KeyEventArgs e) {
            // this is always fired on UI thread
            if (e.Key == Key.Enter) {
                // quick and dirty, but that is not relevant to your question
                _lastLine = Gui.Text.Split(new string[] { "\r\n"}, StringSplitOptions.RemoveEmptyEntries).Last();
                // now, when you detected that user typed a line, set signal
                _readLineSignal.Set();
            }
        }        
        public TextBox Gui { get; private set;}
        public string ReadLine() {
            // that should always be called from non-ui thread
            if (Gui.Dispatcher.CheckAccess())
                throw new  Exception("Cannot be called on UI thread");
            // reset signal
            _readLineSignal.Reset();
            // wait until signal is set. This call is blocking, but since we are on non-ui thread - there is no problem with that
            _readLineSignal.WaitOne();
            // we got signalled - return line user typed.
            return _lastLine;
        }
        public void WriteLine(string line) {
            if (!Gui.Dispatcher.CheckAccess()) {
                Gui.Dispatcher.Invoke(new Action(() => WriteLine(line)));
                return;
            }
            Gui.Text += line + Environment.NewLine;
        }
    }
