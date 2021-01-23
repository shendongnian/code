    private void UpdateLoadingLabel(int percent)
    {
        Application.Dispatcher.BeginInvoke(DispatcherPriority.Background,
        new Action(delegate() { 
             TheBoundProperty = string.Format("Loading {0}/100..", percent);
         }));
    }
