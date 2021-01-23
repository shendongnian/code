    private async void button2_Click(object sender, EventArgs e)
    {
        var taskAwait = 4000;
        var cancellationSource = new CancellationTokenSource();
        var cancellationToken = cancellationSource.Token;
        
        button2.Text = "Processing...";
        
        var usefullWorkTask = Task.Run(async () =>
            {
                try
                {
                    await Task.Dealy(taskAwait);
                }
                catch { }
            },
            cancellationToken);
        
        var progress = new Progress<imt>(i => {
            button2.Text = "Processing " + i.ToString();
        });
        var progressUpdateTask = Task.Run(async () =>
            {
                for(var i = 0; i < 10; i++)
                {
                    progress.Report(i);
                }
            },
            cancellationToken);
            
        await Task.WhenAny(usefullWorkTask, progressUpdateTask);
        
        cancellationSource.Cancel();
    }
