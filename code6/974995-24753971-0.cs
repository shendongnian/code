    private void ButtonClick(object sender, RoutedEventArgs e)
    {
        var process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.EnableRaisingEvents = true;
        process.Exited += ProcessExited;
        process.Start();
        startButton.IsEnabled = false;
    }
    private void ProcessExited(object sender, EventArgs e)
    {
        Dispatcher.BeginInvoke(new Action(() => startButton.IsEnabled = true));
    }
