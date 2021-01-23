    Task.Factory.StartNew(() =>
        {
            Application.Current.Dispatcher.Invoke(() =>
                System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait);
            try
            {
                Thread.Sleep(5000);
            }
            finally
            {
                Application.Current.Dispatcher.Invoke(() =>
                    System.Windows.Input.Mouse.OverrideCursor = null);
            }
        });
