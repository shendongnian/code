    protected void OnStopButtonClicked (object sender, EventArgs e)
    {
        timeLabel.Text = stopwatch.Elapsed.ToString ();
        timer.Stop ();
        timer.Enabled = false;
        timer.Dispose ();
        Console.WriteLine ("Timer stopped");
        stopwatch.Stop ();
        Console.WriteLine ("Stopwatch stopped");
    }
