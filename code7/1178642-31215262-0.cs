    private BackgroundWorker bw1;
    private void button1_Click(object sender, EventArgs e)
    {
        bw1 = new BackgroundWorker();
        bw1.DoWork += new DoWorkEventHandler(bw_DoWork);
        bw1.RunWorkerCompleted += bw_RunWorkerCompleted;
        bw1.RunWorkerAsync();
    }
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        string path = @"F:\DXHyperlink\Book.txt";
        if (File.Exists(path))
        {
            string readText = File.ReadAllText(path);
            foreach (string line in readText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                AppendText(line);
                Thread.Sleep(500);
            }
        }
    }
    private void AppendText(string line)
    {
        if (richTextBox1.InvokeRequired)
        {
            richTextBox1.Invoke((ThreadStart)(() => AppendText(line)));
        }
        else
        {
            richTextBox1.AppendText(line + Environment.NewLine);
        }
    }
