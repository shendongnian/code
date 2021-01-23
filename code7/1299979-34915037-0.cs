        private void formMain_Load(object sender, EventArgs e)
        {
            EventHandler activated = null;
            activated = (s2, e2) =>
            {
                this.Activated -= activated;
                this.ShowInTaskbar = true;
                var splash = new SplashScreen();
                splash.ShowInTaskbar = false;
                splash.Show();
                var timer = new System.Windows.Forms.Timer();
                EventHandler tick = null;
                tick = (s3, e3) =>
                {
                    timer.Enabled = false;
                    timer.Tick -= tick;
                    timer.Dispose();
                    splash.Close();
                    splash.Dispose();
                };
                timer.Tick += tick;
                timer.Interval = 5000;
                timer.Enabled = true;
            };
            this.Activated += activated;
        }
