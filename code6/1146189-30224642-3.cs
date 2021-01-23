      void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                label1.Text = e.ProgressPercentage.ToString();
                label2.Text = e.UserState.ToString();
            }
    
     private void FakeCountingWork()
            {
                int totalNumber = 100;
                int progressCounter = 0;
                Random rnd = new Random();
                while (progressCounter < totalNumber)
                {
                    int fakecounter = 0;
                    for (int x = 0; x < 100000000; x++)
                    {
                        fakecounter++;
                    }
                    progressCounter++;
                   updateValue = rnd.Next();
                  backgroundWorker1.ReportProgress(progressCounter,updateValue);
                }
            }
