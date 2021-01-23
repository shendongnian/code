        private void RemoveDirectories(string strpath)
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                if (Directory.Exists(strpath))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(strpath);
                    var files = dirInfo.GetFiles();
                     //I assume your code is inside a Form, else you need a control to do this invocation;
                    this.BeginInvoke(new Action(() =>
                    {
                        progressBar1.Minimum = 0;
                        progressBar1.Value = 0;
                        progressBar1.Maximum = files.Length;
                        progressBar1.Step = 1;
                    }));
                    foreach (FileInfo file in files)
                    {
                        //file.Delete();
                        this.BeginInvoke(new Action(() => progressBar1.PerformStep())); //I assume your code is inside a Form, else you need a control to do this invocation;
                    }
                    var dirs = dirInfo.GetDirectories();
                    this.BeginInvoke(new Action(() =>
                    {
                        progressBar1.Value = 0;
                        progressBar1.Maximum = files.Length;
                    }));
                    foreach (DirectoryInfo dir in dirs)
                    {
                        //dir.Delete(true);
                        this.BeginInvoke(new Action(() => progressBar1.PerformStep())); //I assume your code is inside a Form, else you need a control to do this invocation;
                    }
                }
            }, null);
        }
