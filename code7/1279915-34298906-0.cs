    public void percentageChanged(int percs)
    {
       Invoke(new Action(() =>
       {
         progressBar1.Value = percs;
       }));
    }
