    button1_Click(object sender, EventArgs e)
    {
        progressBar1.Style = ProgressBarStyle.Marquee;
        progressBar1.MarqueeAnimationSpeed = 50;
    
        
        Task task = Task.Factory.StartNew(() =>
        {
            // INSERT TIME CONSUMING OPERATIONS HERE
            // THAT DON'T REPORT PROGRESS
            Thread.Sleep(10000);
        });
        while (!task.IsCompleted)
        {
             Application.DoEvents();
             Thread.Sleep(1);
        }
        progressBar1.MarqueeAnimationSpeed = 0;
        progressBar1.Style = ProgressBarStyle.Blocks;
        progressBar1.Value = progressBar1.Minimum;
    
    }
