    private void timerCb(object state)
        {
            Dispatcher.Invoke(() =>
            {
                label1.Content = "Foo!";              
            });
        }
