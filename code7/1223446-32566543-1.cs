    public void IncrementProgress()
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.BeginInvoke(
                    new Action(() =>
                    {
                        progressBar1.Value++;
                    }
                        ));
            }
            else
            {
                progressBar1.Value++;
            }
        }
