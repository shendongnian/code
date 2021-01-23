    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        var lines = string.Join("\r\n", lines);
        Invoke((ThreadStart)delegate()
        {
            richEditControl1.Text = lines;
        });
    }
