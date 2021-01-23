    private async void buttonStart_Click(object sender, EventArgs e)
    {           
        await Pause(20000, progressBar1);            
        MessageBox.Show("Done");
    }
    private async Task Pause(int sleepTime, ProgressBar progressBar)
    {            
        int sleepInterval = 50;
        int progressSteps = sleepTime / sleepInterval; //every 50ms feedback
        progressBar1.Maximum = progressSteps;
        SynchronizationContext synchronizationContext = SynchronizationContext.Current; ;
        await Task.Run(() =>
        {
            for (int i = 0; i <= progressSteps; i++)
            {
                Thread.Sleep(sleepInterval);
                synchronizationContext.Post(new SendOrPostCallback(o =>
                {
                    progressBar.Value = (int)o;
                }), i);
            }
        });
    }
    private void buttonMoveButton1_Click(object sender, EventArgs e)
    {
        //to proove UI click several times buttonMove while the task is running
        buttonStart.Top += 10;
    }        
