    private void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        progressBar1.Style = ProgressBarStyle.Marquee;
        progressBar1.MarqueeAnimationSpeed = 50;
        Task.Factory.StartNew(() => {
               // INSERT TIME CONSUMING OPERATIONS HERE
               // THAT DON'T REPORT PROGRESS
               Thread.Sleep(10000);
            }, TaskCreationOptions.LongRunning).
                ContinueWith(t => {
                    progressBar1.MarqueeAnimationSpeed = 0;
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    progressBar1.Value = progressBar1.Minimum;
                    button1.Enabled = true;
                    MessageBox.Show("Done!");
                }, TaskScheduler.FromCurrentSynchronizationContext());
    }
