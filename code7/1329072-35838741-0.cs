    List<string> items = new List<string>() { "item" };
    Dictionary<string, ProgressBar> progressBars = new Dictionary<string, ProgressBar>();
    private void button1_Click(object sender, EventArgs e)
    {
        int count=0; 
        foreach(var item in items)
        {
            count++;
            ProgressBar pBar = new ProgressBar();
            pBar.Name = "progressBar_" + count;
            pBar.Width = 200;
            pBar.Height = 15;
            pBar.Minimum = 1;
            pBar.Maximum = 100;
            pBar.Value = 1;
            panel1.Controls.Add(pBar);
            progressBars.Add(pBar.Name, pBar);
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        progressBars["progressBar_1"].PerformStep();
    }
