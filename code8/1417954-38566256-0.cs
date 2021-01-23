    public partial class TestForm : Form
    {
        private CancellationToken token;
        public TestForm(CancellationToken ct)
        {
            InitializeComponent();
            this.token = ct;
            this.BringToFront();
            DoBackgroundWork();
        }
        private void DoBackgroundWork()
        {
            BackgroundWorker w = new BackgroundWorker();
            w.DoWork += w_DoWork;
            w.RunWorkerCompleted += w_RunWorkerCompleted;
            w.RunWorkerAsync();
        }
        private void w_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
        private void w_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!token.IsCancellationRequested)
            {
               // Form stays open
            }
        }
    }
    // your start class
    public class TestClass
    {
        public void ShowWindowUntilStop()
        {
            System.Threading.CancellationTokenSource cts = new System.Threading.CancellationTokenSource();
            TestForm t = new TestForm(cts.Token);
            t.Show();
            // do some work
            cts.Cancel();
        }
    }
