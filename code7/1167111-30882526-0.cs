    protected override void OnStart(string[] args)
            {
                this.timer = new System.Timers.Timer(10000D);
                this.timer.AutoReset = true;
                this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
                this.timer.Start();
            }
            protected override void OnStop()
            {
                this.timer.Stop();
                this.timer = null;
            }
    
            protected void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                this.proccessQue();
            }
