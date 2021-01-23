        private delegate void LogDelegate(ListBox messageBox, string data);
        private LogDelegate _logDelegate;
        private void Log(ListBox messageBox, string data)
        {
            if (messageBox.InvokeRequired)
            {
                LogDelegate logDelegate = Log;
                Invoke(logDelegate, messageBox, data);
            }
            else
            {
                messageBox.Items.Add(data);
            }
        }
        
        public Form1()
        {
            InitializeComponent();
            //don't forget, initialize the delegate
            _logDelegate = Log;
        }
        
        private void btn_Start_Click(object sender, EventArgs e)
        {
               Log("Anything to log");
        }
        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                //Instead of Invoke use 
                //Invoke(new Action(() => messageBox.Items.Add(usersName.Text + ": " + receivedMessage)));
                Log("Anything to log");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
