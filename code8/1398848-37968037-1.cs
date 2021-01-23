        Multimedia.Timer mmTimer = new Multimedia.Timer(new Container())
        {
            Mode = Multimedia.TimerMode.OneShot,
            Period = 40,
            Resolution = 1,
            SynchronizingObject = this
        };
        mmTimer.Tick += new System.EventHandler(this.mmTimer_Tick);
        startTime = DateTime.Now;
        mmTimer.Start();
        private void mmTimer_Tick(object sender, System.EventArgs e)
        {           
            MessageBox.Show("ticks after 40ms");
        }
