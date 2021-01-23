    DispatcherTimer dispatcherTimer = new DispatcherTimer();
    private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (dispatcherTimer.IsEnabled)
        {
            dispatcherTimer.Stop();
        }
        dispatcherTimer.Start();
    }
    void Method()
    {
        dispatcherTimer.Stop();
        MyAction();
    }
