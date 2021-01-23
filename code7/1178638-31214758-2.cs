    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        // Cpu intensive work happens in the background thread.
        var lines = string.Join("\r\n", lines);
        // The following code is invoked in the UI thread and it only assigns the result.
        // So that the UI is not blocked for long.
        Invoke((ThreadStart)delegate()
        {
            richEditControl1.Text = lines;
        });
    }
