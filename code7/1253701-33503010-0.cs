    Task.Run(() =>
    {
        if (StupidFunction(someParameter))
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => MessageBox.Show(Application.Current.MainWindow, "yes")));
        else
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => MessageBox.Show(Application.Current.MainWindow, "no")));
    });
