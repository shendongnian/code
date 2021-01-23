                    BackgroundWorker bw;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Yes";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += BwOnDoWork;
            bw.WorkerSupportsCancellation = true;
            
            bw.RunWorkerAsync();
            
        }
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            // Display Please Wait Image
            label1.Text = "No";
            
        }
        private void BwOnDoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (!worker.CancellationPending)
            {
                
                if (label1.Text == "No")
                {
                    WebRequest request = null;
                    HttpWebResponse response = null;
                    Stream stream = null;
                    StreamReader reader = null;
                    string url = txtURL.Text.ToString();
                    if (url != "")
                    {
                        try
                        {
                            Application.Run(new Form1());
                            string NavigateURL = "http://" + url + Properties.Settings.Default.portAppName;
                            request = HttpWebRequest.Create(NavigateURL + "connectionParam/PostCon");
                            request.Method = "POST";
                            request.ContentType = "text/xml";
                            response = (HttpWebResponse)request.GetResponse();
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                // My stuff
                                worker.CancelAsync();
                                bw.CancelAsync();
                            }
                        }
                        catch (Exception ex) { }
                    }
                }
            }
            
        }
