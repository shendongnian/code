    private void Button_Click(object sender, RoutedEventArgs e)
    {
        btnStart.IsEnabled = false
        Thread t = new Thread(new ThreadStart(
        delegate
        {
            // Run the main routine;
            BeginBootstrapping();
        }));
        
        t.Start();
    }
