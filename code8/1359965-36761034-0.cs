    void restartButtonClickFunction(object obj)
    {
        Process.Start(Application.ResourceAssembly.Location);
        Application.Current.Shutdown();
    }
