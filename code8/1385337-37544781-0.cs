     private void DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(100);
            int i = (int)e.Argument;
            do
            {   
                i = GeneralProperties.General.currentStep;
                backgroundWorker.ReportProgress((int)Math.Floor((decimal)(8 * i)));
                if (i > GeneralProperties.General.thresholdStep)
                   backgroundWorker.ReportProgress(100);
            }
            while (i < GeneralProperties.General.thresholdStep);
        }
