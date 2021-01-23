        BackgroundWorker m_oWorker;
        public Form1()
        {
            InitializeComponent();
            m_oWorker = new BackgroundWorker();
    
            // Create a background worker thread that ReportsProgress &
            // SupportsCancellation
            // Hook up the appropriate events.
            m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            //optional progress indicators
            m_oWorker.ProgressChanged += new ProgressChangedEventHandler
					(m_oWorker_ProgressChanged);
            m_oWorker.WorkerReportsProgress = true;
        }
        void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Run your primary function
            TestConnection();
            //Progress indicator - optional
            m_oWorker.ReportProgress(100);
        }
        //optional
        void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Report progress
        }
