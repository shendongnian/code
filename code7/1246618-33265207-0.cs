        private System.Threading.Timer timer;
        public void Start()
        {
            timer = new System.Threading.Timer(_ => fireMyCode());
            restartTimer();
        }
        private void onFileChanged(object sender, EventArgs e)
        {
            restartTimer();
        }
        private void restartTimer()
        {
            timer.Change(TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5));
        }
