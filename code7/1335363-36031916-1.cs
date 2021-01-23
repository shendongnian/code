       public Form2()
        {
            InitializeComponent();
            this.progressBar1.Maximum = 1000000;
            this.progressBar1.Minimum = 0;
        }
        public void IncProgress(object Sender, EventArgs e)
        {
            this.progressBar1.PerformStep();
        }
