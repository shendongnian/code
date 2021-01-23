    private void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        //Blah blah blah
        string[] fileNames = arguments[1] as string[];
        ProgressBar1.Value = 0;
        ProgressBar1.Maximum = fileNames.Length;
        while (!worker.CancellationPending && percentFinished < 100)
        {
            foreach (string fileName in fileNames)
            {
                //Blah blah blah
                ProgressBar1.Value += 1;
            }
        }
    }
