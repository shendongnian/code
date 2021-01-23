    foreach (string file in filePathList)
    {
        try
        {
            _busy.WaitOne();
            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
                return;
            }
    
            bool reportedFile = false;
            for (int i = 0; i < textToSearch.Length; i++)
            {
                List<MyProgress> prog = new List<MyProgress>();
                if (File.ReadAllText(file).IndexOf(textToSearch[i], StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    resultsoftextfound.Add(file + "  " + textToSearch[i]);
                    if (!reportedFile)
                    {
                        numberoffiles++;
                        prog.Add(new MyProgress { Report1 = file, Report2 = numberoffiles.ToString(), Report3 = textToSearch[i] });
                        backgroundWorker1.ReportProgress(0, prog);
                        reportedFile = true;
                    }
                }
            }
            numberofdirs++;
            label1.Invoke((MethodInvoker)delegate
            {
                label1.Text = numberofdirs.ToString();
                label1.Visible = true;
            });
        }
        catch (Exception)
        {
            restrictedFiles.Add(file);
            continue;
        }
    }
