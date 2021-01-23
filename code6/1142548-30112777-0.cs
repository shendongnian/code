    class ExceptionReportEventArgs : EventArgs
    {
        public Exception Exception { get; private set; }
        public ExceptionEventArgs(Exception exception)
        {
            Exception = exception;
        }
    }
    class MyNetworkClient
    {
        public event EventHandler<ExceptionReportEventArgs> ExceptionReport;
        private void OnExceptionReport(Exception exception)
        {
            EventHandler<ExceptionReportEventArgs> handler = ExceptionReport;
            if (handler != null)
            {
                handler(this, new ExceptionReportEventArgs(exception));
            }
        }
        // For example...
        private void ClientConnectCallback(IAsyncResult asyncResult)
        {
            try
            {
                /* code omitted */
            }
            catch (SocketException sockEx)
            {
                // if the server isn't running, we'll get a socket exception here
                OnExceptionReport(sockEx);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                OnExceptionReport(ex);
            }
        }
    }
    partial class MyForm : Form
    {
        private MyNetworkClient _client;
        public MyForm()
        {
            InitializeComponent();
            _client = new MyNetworkClient();
            _client.ExceptionReport += (sender, e) =>
            {
                BeginInvoke((MethodInvoker)(() =>
                    MessageBox.Show(e.Exception.Message, Application.ProductName,
                        MessageBoxButtons.OK, MessageBoxIcon.Error)));
            };
        }
    }
