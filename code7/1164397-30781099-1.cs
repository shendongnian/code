    private void PopList()
    {
        sw.Start();
        int max = 10000000;
        int oldProgress = 0;
        for (int i = 1; i <= max; i++)
        {
            numbersList.Add("Hello World! [" + i + "]");
            int progressPercentage = Convert.ToInt32((double)i / max * 100);
            // Only report progress when it changes
            if (progressPercentage != oldProgress)
            {
                Dispatcher.BeginInvoke(new Action(() => { pb.Value = progressPercentage; }));                    
                oldProgress = progressPercentage;
            }
        }
        Dispatcher.BeginInvoke(new Action(() => { lstLoremIpsum.ItemsSource = numbersList; }));
    }
