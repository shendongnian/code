    private async void Install(object sender, RoutedEventArgs e)
    {
        progressBar.Value = 5;
    
        await Task.Run(() => installer.InstallProgram1());
    
        progressBar.Value = 25;
    
        await Task.Run(() => installer.InstallProgram2());
    
        progressBar.Value = 50;
    
        await Task.Run(() => installer.InstallProgram3());
    
        progressBar.Value = 75;
    
        await Task.Run(() => installer.InstallProgram4());
    
        progressBar.Value = 100;
    }
