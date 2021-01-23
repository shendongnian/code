    using System.IO.Ports;
    using System.Timers;
    
    namespace BarCode_manager
    {
        public partial class MainWindow : Window
        {
    
            private static SerialPort currentPort = new SerialPort();
            private static System.Timers.Timer aTimer;
    
            private delegate void updateDelegate(string txt);
    
            public MainWindow()
            {
                InitializeComponent();
                currentPort.PortName = "COM6";
                currentPort.BaudRate = 9600;
                currentPort.ReadTimeout = 1000;
    
                aTimer = new System.Timers.Timer(1000);
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
            }
    
            private void OnTimedEvent(object sender, ElapsedEventArgs e)
            {
               if (!currentPort.IsOpen)
                {
                    currentPort.Open();
                    System.Threading.Thread.Sleep(100); /// for recieve all data from scaner to buffer
                    currentPort.DiscardInBuffer();      /// clear buffer          
                }
                try
                {
                    string strFromPort = currentPort.ReadExisting();
                    lblPortData.Dispatcher.BeginInvoke(new updateDelegate(updateTextBox), strFromPort);
                }
                catch { }
            }
    
            private void updateTextBox(string txt)
            {
                if (txt.Length != 0)
                {
                    aTimer.Stop();
                    aTimer.Dispose();
                    txtReceive.Text = Convert.ToString(aTimer.Enabled);
                    currentPort.Close();
                }
                lblPortData.Text = txt;
                lblCount.Content = txt.Length;
                txtReceive.Text = Convert.ToString(aTimer.Enabled);
            }          
    
            private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                if (currentPort.IsOpen)
                    currentPort.Close();
            }
        }
    }
