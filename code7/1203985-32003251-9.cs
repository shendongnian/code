    private void button1_Click(object sender, EventArgs e)
    {
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        backgroundWorker.WorkerReportsProgress = true;
        backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
        backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        backgroundWorker.DoWork += backgroundWorker_DoWork;
        backgroundWorker.RunWorkerAsync(new string[] { @"C:\Temp\lst.txt", @"C:\Temp\output" });
    }
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        string[] arguments = (string[])e.Argument;
        string source = arguments[0];
        string dest = arguments[1];
        const int updateMilliseconds = 100;
        int index = 0;
        int i = 0;
        StreamWriter writefile = null;
        try
        {
            using (StreamReader readfile = new StreamReader(source))
            {
                writefile = new StreamWriter(dest + index);
                // Initial value "back in time". Forces initial update
                int milliseconds = unchecked(Environment.TickCount - updateMilliseconds);
                string content;
                while ((content = readfile.ReadLine()) != null)
                {
                    writefile.Write(content);
                    writefile.Write("\r\n"); // Splitted to remove a string concatenation
                    i++;
                    if (i % 1000000 == 0)
                    {
                        index++;
                        writefile.Dispose();
                        writefile = new StreamWriter(dest + index);
                        // Force update
                        milliseconds = unchecked(milliseconds - updateMilliseconds);
                    }
                    int milliseconds2 = Environment.TickCount;
                    int diff = unchecked(milliseconds2 - milliseconds);
                    if (diff >= updateMilliseconds)
                    {
                        milliseconds = milliseconds2;
                        worker.ReportProgress(0, new int[] { index, i });
                    }
                }
            }
        }
        finally
        {
            if (writefile != null)
            {
                writefile.Dispose();
            }
        }
        // For the RunWorkerCompleted
        e.Result = new int[] { index, i };
    }
    void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        int[] state = (int[])e.UserState;
        label5.Text = string.Format("File {0}, line {1}", state[0], state[1]);
    }
    void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        int[] state = (int[])e.Result;
        label5.Text = string.Format("File {0}, line {1} Finished", state[0], state[1]);
    }
