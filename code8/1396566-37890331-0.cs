    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        _stopwatch.Restart();
        DirSearch(@"d:\c-sharp", "*.cs", "Form1", e);
        _stopwatch.Stop();
    }
    private void DirSearch(string root, string filesExtension,string textToSearch, DoWorkEventArgs e)
    {
        int numberoffiles = 0;
        int numberofdirs = 0;
        string[] filePaths = Directory.GetFiles(root, filesExtension, SearchOption.AllDirectories);
        for (int i = 0; i < filePaths.Length; i++)
        {
            if (e.Cancel == true)
            {
                return;
            }
            List<MyProgress> prog = new List<MyProgress>();
            int var = File.ReadAllText(filePaths[i]).Contains(textToSearch) ? 1 : 0;
            if (var == 1)
            {
                string filename = filePaths[i];
                numberoffiles ++;
                prog.Add(new MyProgress { Report1 = filename, Report2 = numberoffiles.ToString() });
                backgroundWorker1.ReportProgress(0, prog);
                Thread.Sleep(100);
            }
            numberofdirs ++;
            label1.Invoke((MethodInvoker)delegate
                        {
                            label1.Text = numberofdirs.ToString();
                            label1.Visible = true;
                        });
        }
    }
