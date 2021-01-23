    BackgroundWorker _bw; // You need to initialize this somewhere.
    private void adjustStatsButton_Click(object sender, EventArgs e)
    {
        // Maybe this should be initialized in ctor. But for this example we do it here...
        _bw = new BackgroundWorker();
        var arguments = new BqArguments
        {
           Winner = winnerInput.Text,
           Loser = loserInput.Text
        }
        _bw.DoWork += bw_DoWork;
        _bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        _bw.RunWorkerAsync(arguments);    
    }
    private void bw_DoWork (object sender, DoWorkEventArgs e)
    {
        // Run your query in the background.
        var arguments = e.Argument as BqArguments;
        ReadWrite.AdjustStats(arguments.Winner, arguments.Loser);
    }
    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // All done. Let's update the GUI.
        winnerInput.Text = "";
        loserInput.Text = "";
        Refresh(leaderboardBox);
    }
