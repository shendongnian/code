    public partial class Form1 : Form
    {
        private CancellationTokenSource _cancellationTokenSource;
        public Form1()
        {
            InitializeComponent();
            btnAbort.Enabled = false;
        }
        private void btnCall_Click(object sender, EventArgs e)
        {
            btnCall.Enabled = false;
            btnAbort.Enabled = true;
            lblStatus.Text = "CALLING SERVER...";
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationTokenSource.Token.Register(() => backgroundWorker1.CancelAsync());
            backgroundWorker1.RunWorkerAsync();
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    var call = CallServerAsync("ServerName", "ActionName");
                    call.Wait(_cancellationTokenSource.Token);
                    e.Result = call.Result;
                }
            }
            catch (TaskCanceledException)
            {
                e.Cancel = true;
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnCall.Enabled = true;
            btnAbort.Enabled = false;
            lblStatus.Text = (e.Error != null ? "CALL FAILED: " + e.Error.Message : "CALL COMPLETED!");
        }
        private async Task<string> CallServerAsync(string serverName, string actionName)
        {
            WebService1SoapClient client = new WebService1SoapClient();
            var response = await client.HelloWorldAsync();
            return response.Body.HelloWorldResult;
        }
    }
